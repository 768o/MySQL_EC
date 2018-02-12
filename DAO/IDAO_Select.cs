using System.Collections.Generic;
using System.Data;

namespace MySQL_EC
{
    interface IDAO_Select
    {
        DataTable Select(string table_name, List<SQLRequirement> Requirement_list);
    }
}
