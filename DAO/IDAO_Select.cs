using System.Collections.Generic;
using System.Data;

namespace MySQL_EC
{
    ///<summary> 用来对数据库进行查询相关操作 </summary> 
    public interface IDAO_Select
    {
        /// <summary> 数据库查询操作 </summary>
        /// <param name="table_name">表名</param>
        /// <param name="Requirement_list"> 操作的数据(where) </param>
        /// <param name="ShowFiled"> 需要显示的字段 </param>
        /// <returns> 查询的结果 </returns>
        DataTable Select(string table_name, List<SQLRequirement> Requirement_list, string ShowFiled);
    }
}
