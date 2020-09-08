using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Tauridia.Console.Test
{
    [DataContract]
    public class BaseModel
    {
        public BaseModel()
        {
            Name = "BaseModel";
        }

        [DataMember]
        public string Name { get; set; }

        [IgnoreDataMember]
        public List<BaseModel> ItemsBase { get; set; } = new List<BaseModel>(new BaseModel[] { new BaseModel() { Name = "OneBase" }, new BaseModel() { Name = "TwoBase" } });
    }

    [DataContract]
    public class OneModel :BaseModel
    {
        public OneModel()
        {
            Name = "OneModel";
        }
        [DataMember]
        public List<BaseModel> Items { get; set; }  = new List<BaseModel>(new BaseModel[] { new BaseModel() { Name = "One" }, new BaseModel() { Name = "Two" } });
    }

    [DataContract]
    public class TwoModel : OneModel
    {
        public TwoModel()
        {
            Name = "TwoModel";
        }
    }
}
