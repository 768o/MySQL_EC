
using System.Collections.Generic;

namespace MySQL_EC
{
    /// <summary>
    /// 
    /// </summary>
    public interface IService_Delete
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int Delete(string table_name, List<SQLRequirement> Requirement_list);
    }
}
