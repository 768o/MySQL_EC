using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_EC
{
    class Test
    {
        static void Main(string[] args) { 
            IService service = new ServiceImpl();

            List<SQLRequirement> requirements = new List<SQLRequirement> {
                new SQLRequirement{ Field = "id",Mode = "like", Key = "5" },
                new SQLRequirement{ Field = "number",Mode = "=", Key = "A5" },
            };
            //相当于 select * from table where id like '%5%' and number = A5;
            string a = service.Select("table", requirements);
            Console.Write(a);
            Console.ReadLine();
        }
    }
}
