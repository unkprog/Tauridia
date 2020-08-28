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
    public T Id {get;set;}
}

}
