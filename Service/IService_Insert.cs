
using System.Collections.Generic;

namespace MySQL_EC
{
    /// <summary>
    /// 
    /// </summary>
    public interface IService_Insert
    {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="table_name"></param>
    /// <param name="Requirement_list"></param>
    /// <returns></returns>
        int Insert(string table_name, List<SQLRequirement> Requirement_list);
    }
}
