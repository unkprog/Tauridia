using Microsoft.AspNetCore.Mvc.Formatters;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace Tauridia.Web.Core.Formatters
{
    public class Utf8JsonOutputFormatter : IOutputFormatter //, IApiResponseTypeMetadataProvider
    {
        const string ContentType = "application/json";
        static readonly string[] SupportedContentTypes = new[] { ContentType };

        readonly IJsonFormatterResolver resolver;

        public Utf8JsonOutputFormatter()
            : this(null)
        {

        }
        public Utf8JsonOutputFormatter(IJsonFormatterResolver resolver)
        {
            this.resolver = resolver ?? JsonSerializer.DefaultResolver;
        }

        //public IReadOnlyList<string> GetSupportedContentTypes(string contentType, Type objectType)
        //{
        //    return SupportedContentTypes;
        //}

        public bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            return true;
        }

        public Task WriteAsync(OutputFormatterWriteContext context)
        {
            context.HttpContext.Response.ContentType = ContentType;

            // when 'object' use the concrete type(object.GetType())
            if (context.ObjectType == typeof(object))
            {
                return JsonSerializer.NonGeneric.SerializeAsync(context.HttpContext.Response.Body, context.Object, resolver);
            }
            else
            {
                return JsonSerializer.NonGeneric.SerializeAsync(context.ObjectType, context.HttpContext.Response.Body, context.Object, resolver);
            }
        }
    }

    public class Utf8JsonInputFormatter : IInputFormatter // , IApiRequestFormatMetadataProvider
    {
        const string ContentType = "application/json";
        static readonly string[] SupportedContentTypes = new[] { ContentType };

        readonly IJsonFormatterResolver resolver;

        public Utf8JsonInputFormatter()
            : this(null)
        {

        }

        public Utf8JsonInputFormatter(IJsonFormatterResolver resolver)
        {
            this.resolver = resolver ?? JsonSerializer.DefaultResolver;
        }

        //public IReadOnlyList<string> GetSupportedContentTypes(string contentType, Type objectType)
        //{
        //    return SupportedContentTypes;
        //}

        public bool CanRead(InputFormatterContext context)
        {
            return true;
        }

        public Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;

            //byte[] ss = new byte[request.Body.Length + 10];
            //request.Body.Read(ss, 0, (int)request.Body.Length);
            //string sss = System.Text.UTF8Encoding.UTF8.GetString(ss);
            var reader = new StreamReader(request.Body);
            //reader.BaseStream.Seek(0, SeekOrigin.Begin);
            var rawMessage = reader.ReadToEnd();
            //var result0 = JsonSerializer.NonGeneric.Deserialize(typeof(Project), rawMessage);
            var result = JsonSerializer.NonGeneric.Deserialize(context.ModelType, rawMessage, resolver);
            //var result = JsonSerializer.NonGeneric.Deserialize(context.ModelType, new StreamReader(request.Body).BaseStream, resolver);
            return InputFormatterResult.SuccessAsync(result);
        }
    }
}
