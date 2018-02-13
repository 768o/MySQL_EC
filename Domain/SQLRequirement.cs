using System;
using System.Runtime.Serialization;

namespace MySQL_EC
{
    ///<summary>
    ///class<c>SQLRequirement</c>
    ///对数据库查询条件进行封装
    ///</summary> 
    [DataContract]
    public class SQLRequirement
    {
        /// <summary>
        /// 查询的字段
        /// </summary>
        [DataMember]
        public string Field { set; get; }
        /// <summary>
        /// 查询的模式，equal或like
        /// </summary>
        [DataMember]
        public string Mode { set; get; }
        /// <summary>
        /// 查询的关键字
        /// </summary>
        [DataMember]
        public string Value { set; get; }
    }
}