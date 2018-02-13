using System;
using System.Collections.Generic;

namespace MySQL_EC
{
    class Test
    {
        static void Main(string[] args) { 
            IService service = new ServiceImpl();
            IDAO dao = new DAOImpl();

            List<SQLRequirement> select = new List<SQLRequirement> {
                new SQLRequirement{ Field = "id",Mode = "like", Value = "" },
                new SQLRequirement{ Field = "number",Mode = "=", Value = "A5" },
            };
            //相当于 select id,number,name from table where id like '%%' and number = A5;
            string a = service.Select("table", select,"id,number,name");
            //默认为*
             string a1 = service.Select("table", select,"id,number,name");
            //-----------------------------------------------------------------以上SELECT
            //如果value中有关键字，用''不然有错
            List<SQLRequirement> update = new List<SQLRequirement> {
                new SQLRequirement{ Field = "id", Value = "91887" },
                new SQLRequirement{ Field = "number", Value = "'table'" },
                new SQLRequirement{ Field = "table", Value = "77" },
            };
            int b = service.Insert("table",update);
            Console.Write(b);
            //-----------------------------------------------------------------以上INSERT

            Console.WriteLine(a);
            Console.WriteLine(a1);
            Console.ReadLine();
        }
    }
}
