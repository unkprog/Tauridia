using System;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Tauridia.Core.Extensions
{
    public static partial class Json
    {
        public class SerializeOptions
        {
            public Dictionary<string, bool> ExcludeProperties = new Dictionary<string, bool>();
        }

        internal class JsonSerializer
        {
            internal JsonSerializer(SerializeOptions aOptions = null)
            {
                options = aOptions == null ? new SerializeOptions() : aOptions;
            }

            internal string ToJson(object obj)
            {
                WriteValue(obj);
                return _output.ToString();
            }

            private SerializeOptions options;
            private StringBuilder _output = new StringBuilder();

            private bool _useEscapedUnicode = false;
            private bool _useFastGuid = false;
            private bool _useDateTimeMilliseconds = false;
            //private bool _useInlineCircularReferences = false;
            //private bool _useGlobalTypes = false;

            private int _useMaxRecursionDepth = 200;

            static Type tString = typeof(string);
            static Type tChar = typeof(char);
            static Type tBool = typeof(bool);
            static Type tInt = typeof(int);
            static Type tLong = typeof(long);
            static Type tDecimal = typeof(decimal);
            static Type tByte = typeof(byte);
            static Type tShort = typeof(short);
            static Type tSbyte = typeof(sbyte);
            static Type tUshort = typeof(ushort);
            static Type tUint = typeof(uint);
            static Type tUlong = typeof(ulong);
            static Type tDouble = typeof(double);
            static Type tFloat = typeof(float);
            static Type tSingle = typeof(Single);
            static Type tDateTime = typeof(DateTime);
            static Type tByteArray = typeof(byte[]);
            static Type tGuid = typeof(Guid);
            static Type tObject = typeof(object);
            static Type tObjectArray = typeof(object[]);

            static Type tDataContractAttribute = typeof(DataContractAttribute);
            static Type tDataMemberAttribute   = typeof(DataMemberAttribute);

            private void WriteValue(object obj)
            {
                if (obj == null)
                {
                    _output.Append("null");
                    return;
                }
                Type t = obj.GetType();

                //if (!(Attribute.IsDefined(t, tDataContractAttribute) || Attribute.IsDefined(t, tDataMemberAttribute)))
                //    return;

                if (t == tString || t == tChar) WriteString(obj.ToString());
                else if (t == tGuid) WriteGuid((Guid)obj);
                else if (t == tBool) _output.Append(((bool)obj) ? "true" : "false");
                else if (t == tInt) _output.Append((int)obj);
                else if (t == tLong) _output.Append((long)obj);
                else if (t == tDecimal) _output.Append((decimal)obj);
                else if (t == tInt || t == tLong ||
                         t == tDecimal ||
                         t == tByte || t == tShort ||
                         t == tSbyte || t == tUshort ||
                         t == tUint || t == tUlong
                        )
                    _output.Append(((IConvertible)obj).ToString(NumberFormatInfo.InvariantInfo));
                else if (t == tDouble)
                {
                    double d = (double)obj;
                    if (double.IsNaN(d))
                        _output.Append("\"NaN\"");
                    else
                        _output.Append(((IConvertible)obj).ToString(NumberFormatInfo.InvariantInfo));
                }
                else if (t == tFloat || t == tSingle)
                {
                    float d = (float)obj;
                    if (float.IsNaN(d))
                        _output.Append("\"NaN\"");
                    else
                        _output.Append(((IConvertible)obj).ToString(NumberFormatInfo.InvariantInfo));
                }
                else if (t == tDateTime) WriteDateTime((DateTime)obj);
                else if (t == tByteArray) WriteBytes((byte[])obj);
                else if (t == tObjectArray || obj is IEnumerable) WriteArray((IEnumerable)obj);
                else if (obj is IDictionary) WriteDictionary((IDictionary)obj);
                else
                    WriteObject(obj);
            }


            private void WriteGuid(Guid g)
            {
                if (!_useFastGuid)
                    WriteStringFast(g.ToString());
                else
                    WriteBytes(g.ToByteArray());
            }

            private void WriteBytes(byte[] bytes)
            {
                WriteStringFast(Convert.ToBase64String(bytes, 0, bytes.Length));
            }

            private void WriteArray(IEnumerable array)
            {
                bool pendingSeperator = false;

                _output.Append('[');
                foreach (object obj in array)
                {
                    if (pendingSeperator) _output.Append(',');
                    WriteValue(obj);
                    pendingSeperator = true;
                }
                _output.Append(']');
            }

            private void WritePairFast(string name, string value)
            {
                WriteStringFast(name);
                _output.Append(':');
                WriteStringFast(value);
            }

            private void WritePair(string name, object value)
            {
                WriteString(name);
                _output.Append(':');
                WriteValue(value);
            }
            private void WriteDictionary(IDictionary dic)
            {
                _output.Append('[');

                bool pendingSeparator = false;

                foreach (DictionaryEntry entry in dic)
                {
                    if (pendingSeparator) _output.Append(',');
                    _output.Append('{');
                    WritePair("k", entry.Key);
                    _output.Append(",");
                    WritePair("v", entry.Value);
                    _output.Append('}');

                    pendingSeparator = true;
                }
                _output.Append(']');
            }

            private void WriteDateTime(DateTime dateTime)
            {
                _output.Append('\"');
                _output.Append(dateTime.ToString(_useDateTimeMilliseconds ? "yyyy-MM-ddTHH:mm:ss.fff" : "yyyy-MM-ddTHH:mm:ss"));
                _output.Append('\"');
            }
            private void WriteStringFast(string s)
            {
                _output.Append('\"');
                _output.Append(s);
                _output.Append('\"');
            }

            private void WriteString(string s)
            {
                _output.Append('\"');

                int runIndex = -1;
                int l = s.Length;
                for (var index = 0; index < l; ++index)
                {
                    var c = s[index];

                    if (_useEscapedUnicode)
                    {
                        if (c >= ' ' && c < 128 && c != '\"' && c != '\\')
                        {
                            if (runIndex == -1)
                                runIndex = index;

                            continue;
                        }
                    }
                    else
                    {
                        if (c != '\t' && c != '\n' && c != '\r' && c != '\"' && c != '\\')// && c != ':' && c!=',')
                        {
                            if (runIndex == -1)
                                runIndex = index;

                            continue;
                        }
                    }

                    if (runIndex != -1)
                    {
                        _output.Append(s, runIndex, index - runIndex);
                        runIndex = -1;
                    }

                    switch (c)
                    {
                        case '\t': _output.Append("\\t"); break;
                        case '\r': _output.Append("\\r"); break;
                        case '\n': _output.Append("\\n"); break;
                        case '"':
                        case '\\': _output.Append('\\'); _output.Append(c); break;
                        default:
                            if (_useEscapedUnicode)
                            {
                                _output.Append("\\u");
                                _output.Append(((int)c).ToString("X4", NumberFormatInfo.InvariantInfo));
                            }
                            else
                                _output.Append(c);

                            break;
                    }
                }

                if (runIndex != -1)
                    _output.Append(s, runIndex, s.Length - runIndex);

                _output.Append('\"');
            }

            //bool _TypesWritten = false;
            int _current_depth = 0;

            private Dictionary<object, int> _cirсularobj = new Dictionary<object, int>();
            private void WriteObject(object obj)
            {
                int i = 0;
                if (!_cirсularobj.TryGetValue(obj, out i))
                    _cirсularobj.Add(obj, _cirсularobj.Count + 1);

                _output.Append('{');

                //_TypesWritten = true;
                _current_depth++;
                if (_current_depth > _useMaxRecursionDepth)
                    throw new Exception("Serializer encountered maximum depth of " + _useMaxRecursionDepth);


                Dictionary<string, string> map = new Dictionary<string, string>();
                Type t = obj.GetType();
                bool append = false, isWrite;

                IEnumerable<PropertyInfo> properties = t.GetRuntimeProperties();
                foreach (var propertie in properties)
                {
                    isWrite = true;
                    if (!options.ExcludeProperties.TryGetValue(propertie.Name, out isWrite) || isWrite)
                    {
                        if (append)
                            _output.Append(',');
                        WritePair(propertie.Name, propertie.GetValue(obj));
                        append = true;
                    }
                }
                _output.Append('}');
                _current_depth--;
            }
        }
    }
}
