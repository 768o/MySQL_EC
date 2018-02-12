using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_EC
{
    class Class1
    {
        static void Main(string[] args) { 
        IService service = new ServiceImpl();

        List<SQLRequirement> requirements = new List<SQLRequirement>();
        requirements.Add(new SQLRequirement("polygon_id", "like", "1"));

        string a = service.Select("table_name", requirements);
        }
    }
}
