using System;
using System.Collections.Generic;
using System.Text;

namespace Tauridia.Core.Models.Record
{
    public abstract class RecordModel : ModelBase
    {
    }

    public abstract class Record<T> : RecordModel
    {
        public T Id { get; set; }
        public bool Deleted { get; set; }
    }

    public abstract class RecordHierarhy<T> : Record<T>
    {
        public T ParentId { get; set; }
    }

    public abstract class RecordReference<T> : RecordHierarhy<T>
    {
        public string Name { get; set; }
    }

    public abstract class RecordDocument<T> : RecordHierarhy<T>
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
