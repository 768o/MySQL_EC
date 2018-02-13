using System.Collections.Generic;

namespace MySQL_EC
{
    ///<summary>
    ///interface<c>IDAO_Delete</c>
    ///用来对数据库进行删除相关操作
    ///</summary> 
    interface IDAO_Delete
    {
        int Delete(string table_name, List<SQLRequirement> Requirement_list);
    }
}
