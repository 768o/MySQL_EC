using System;
using System.Collections.Generic;

namespace MySQL_EC
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceImpl : IService
    {
        IDAO dao = new DAOImpl();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {

            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="Requirement_list">条件</param>
        /// <returns></returns>
        public string Select(string table_name, List<SQLRequirement> Requirement_list)
        {
            foreach (SQLRequirement requirement in Requirement_list)
            {
                if ("like".Equals(requirement.Mode))
                {
                    requirement.Mode = " like ";
                    requirement.Key = "%" + requirement.Key + "%";
                }
                else requirement.Mode = " = ";
            }
            return ObjToJSON.DataTableToJsonWithJavaScriptSerializer(dao.Select(table_name, Requirement_list));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}