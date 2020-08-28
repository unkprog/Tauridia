using System;

namespace Tauridia.Core.Models.Record
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class BaseAttribute : Attribute
    {
        // Имя
        public string Name { get; set; }
        // Описание
        public string Description { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class RecordClassAttribute : BaseAttribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class RecordPropertyAttribute : BaseAttribute
    {
    }
}
