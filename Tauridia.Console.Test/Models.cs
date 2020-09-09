using System.Collections.Generic;
using System.Runtime.Serialization;

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

    }

    [DataContract]
    public class OneModel :BaseModel
    {
        public OneModel()
        {
            Name = "OneModel";
        }
        public List<BaseModel> OneItems { get; set; } = new List<BaseModel>(new BaseModel[] { new BaseModel() { Name = "One" }, new BaseModel() { Name = "Two" } });
    }

    [DataContract]
    public class TwoModel : OneModel
    {
        public TwoModel()
        {
            Name = "TwoModel";
        }

        [DataMember]
        public List<BaseModel> Items { get; set; } = new List<BaseModel>(new BaseModel[] { new BaseModel() { Name = "One BaseModel" }, new OneModel() { Name = "Two OneModel" } });
    }
}
