using System;
using System.Collections.Generic;

namespace MySQL_EC
{
    public class ServiceImpl : IService
    {
        IDAO dao = new DAOImpl();
        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Insert()
        {

            throw new NotImplementedException();
        }

        public string Select(string table_name, List<SQLRequirement> Requirement_list)
        {
            foreach (SQLRequirement requirement in Requirement_list)
            {
                if ("like".Equals(requirement.mode))
                {
                    requirement.mode = " like ";
                    requirement.key = "%" + requirement.key + "%";
                }
                else
                    requirement.mode = " = ";
            }
            return ObjToJSON.DataTableToJsonWithJavaScriptSerializer(dao.Select(table_name, Requirement_list));
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}