using System.Collections.Generic;

namespace MySQL_EC
{
    ///<summary> 用来对数据库进行添加相关操作 </summary> 
    public interface IDAO_Insert
    {
        /// <summary> 数据库插入操作 </summary>
        /// <param name="table_name">表名</param>
        /// <param name="Requirement_list"> 操作的数据(where) </param>
        /// <returns>影响的行数</returns>
        int Insert(string table_name, List<SQLRequirement> Requirement_list);
    }
}
