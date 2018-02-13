using System.Collections.Generic;
using System.Data;

namespace MySQL_EC
{
    ///<summary>
    ///interface<c>IDAO_Select</c>
    ///用来对数据库进行查询相关操作
    ///</summary> 
    interface IDAO_Select
    {
        ///<summary>
        ///查询的方法
        ///</summary> 
        ///<param name="table_name">查询表的名字</param>
        ///<param name="Requirement_list">查询表的条件列表<seealso cref="MySQL_EC.SQLRequirement">见SQLRequirement类</seealso></param>
        ///<param name="ShowFiled"></param>
        ///<returns>返回查询的结果DateTable</returns>
        DataTable Select(string table_name, List<SQLRequirement> Requirement_list, string ShowFiled);
    }
}
