
using System.Collections.Generic;

namespace MySQL_EC
{
    ///<summary> 用来对数据库进行更新相关操作 </summary> 
    public interface IDAO_Update
    {
        /// <summary> 数据库更新操作 </summary>
        /// <param name="table_name"> 表名 </param>
        /// <param name="Set_list"> 操作的数据(set) </param>
        /// <param name="Requirement_list"> 操作的数据(where) </param>
        /// <returns> 影响的行数 </returns>
        int Update(string table_name, List<SQLRequirement> Set_list, List<SQLRequirement> Requirement_list);
    }
}
