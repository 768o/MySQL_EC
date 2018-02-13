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
            string a1 = service.Select("table", select);
            //-----------------------------------------------------------------以上SELECT
            //Value如果有关键字会错误,需要加''
            List<SQLRequirement> update = new List<SQLRequirement> {
                new SQLRequirement{ Field = "id", Value = "9799998" },
                new SQLRequirement{ Field = "number", Value = "'table'" },
                new SQLRequirement{ Field = "table", Value = "77" },
            };
            int b = service.Insert("table",update);
            //-----------------------------------------------------------------以上INSERT
            Console.Write(b);
            Console.Write(a);
            Console.Write(a1);
            Console.ReadLine();
        }
    }
}
