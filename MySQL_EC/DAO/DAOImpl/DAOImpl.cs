using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace MySQL_EC
{

    public class DAOImpl : IDAO
    {
        public bool Insert()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public DataTable Select(string table_name, List<SQLRequirement> Requirement_list)
        {
            StringBuilder requirements = new StringBuilder();
            int list_count = Requirement_list.Count;
            foreach (SQLRequirement requirement in Requirement_list)
            {
               string requirement_str = String.Format("{0}{1}{2}{3}{4}", requirement.field, requirement.mode,
                    "'", requirement.key, "'");
                requirements.Append(requirement_str);
                if (list_count-- > 1)
                    requirements.Append(" and ");
            }
            string sql = String.Format("{0}{1}{2}{3}", "select * from ", table_name, " where ", requirements);
            return MySqlHelper.ExecuteQuery(sql);
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

    }
}