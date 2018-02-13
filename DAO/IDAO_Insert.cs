using System.Collections.Generic;

namespace MySQL_EC
{
    ///<summary>
    ///interface<c>IDAO_Insert</c>
    ///用来对数据库进行添加相关操作
    ///</summary> 
    interface IDAO_Insert
    {
        int Insert(string table_name, List<SQLRequirement> Requirement_list);
    }
}
