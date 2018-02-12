using System.Collections.Generic;
using System.Data;

namespace MySQL_EC
{
    public interface IService_Select
    {
        string Select(string table_name, List<SQLRequirement> Requirement_list);
    }
}
