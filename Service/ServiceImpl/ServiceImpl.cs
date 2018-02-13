using System;
using System.Collections.Generic;
using System.Data;

namespace MySQL_EC
{
    /// <summary>
    /// 确保传入数据与传出数据的规范
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
        /// <param name="table_name"></param>
        /// <param name="Requirement_list"></param>
        /// <returns></returns>
        public int Insert(string table_name, List<SQLRequirement> Requirement_list)
        {
            table_name = MySQLKeyWordCancel(table_name);
            Requirement_list = MySQLKeyWordCancelPlus(Requirement_list);

            return dao.Insert(table_name, Requirement_list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="Requirement_list">条件</param>
        /// <param name="ShowFiled">需要显示的字段，默认为*</param>
        /// <returns></returns>
        public string Select(string table_name, List<SQLRequirement> Requirement_list, string ShowFiled = "*")
        {
            table_name = MySQLKeyWordCancel(table_name);
            Requirement_list = MySQLKeyWordCancelPlus(Requirement_list);

            DataTable datatable = dao.Select(table_name, Requirement_list, ShowFiled);
            return ObjToJSON.DataTableToJsonWithJavaScriptSerializer(datatable);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 避免你的list内容里面存在MySQL关键字
        /// </summary>
        private List<SQLRequirement> MySQLKeyWordCancelPlus(List<SQLRequirement> Requirement_list)
        {
            foreach (SQLRequirement requirement in Requirement_list)
            {
                requirement.Field = MySQLKeyWordCancel(requirement.Field);
                //requirement.Value = MySQLKeyWordCancel(requirement.Value);
                if ("like".Equals(requirement.Mode))
                    requirement.Value = "%" + requirement.Value + "%";
            }
            return Requirement_list;
        }
        /// <summary>
        /// 避免你的字符是MySQL关键字
        /// </summary>
        /// <param name="MaybeMySQLKeyWord">可能是关键字的字符串</param>
        /// <returns>加了``转移字符的字符串</returns>
        private string MySQLKeyWordCancel(string MaybeMySQLKeyWord) {
            return " `"+ MaybeMySQLKeyWord + "` ";
        }
    }
}