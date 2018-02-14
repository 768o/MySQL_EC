
using System.Collections.Generic;

namespace MySQL_EC
{
    /// <summary>
    /// 
    /// </summary>
    public interface IService_Update
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int Update(string table_name, List<SQLRequirement> Set_list, List<SQLRequirement> Requirement_list);
    }
}
