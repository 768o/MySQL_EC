using System;
using System.Runtime.Serialization;

namespace MySQL_EC
{
    [DataContract]
    public class SQLRequirement
    {
        [DataMember]
        public string field { set; get; }
        [DataMember]
        public string mode { set; get; }
        [DataMember]
        public string key { set; get; }

        public SQLRequirement(string field, string mode, string key) {
            this.field = field;
            this.mode = mode;
            this.key = key;
        }
    }
}