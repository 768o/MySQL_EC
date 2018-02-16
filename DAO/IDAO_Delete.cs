using System.Collections.Generic;

namespace MySQL_EC
{
    ///<summary> 用来对数据库进行删除相关操作 </summary> 
    public interface IDAO_Delete
    {
        /// <summary> 数据库删除操作 </summary>
        /// <param name="table_name"> 表名 </param>
        /// <param name="Requirement_list"> 操作的数据(where) </param>
        /// <returns> 影响的行数 </returns>
        int Delete(string table_name, List<SQLRequirement> Requirement_list);
    }
}
