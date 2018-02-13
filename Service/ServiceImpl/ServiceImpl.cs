using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace MySQL_EC
{
    /// <summary>
    /// 确保传入数据与传出数据的规范
    /// </summary>
    public class ServiceImpl : IService
    {
        IDAO dao = new DAOImpl();
        /// <summary>
        /// 删除
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
            string table_name_NoKey = MySQLKeyWordCancel(table_name);
            List<SQLRequirement> Requirement_list_NoKey = MySQLKeyWordCancelPlus(Requirement_list);

            return dao.Insert(table_name_NoKey, Requirement_list_NoKey);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="Requirement_list">条件</param>
        /// <param name="ShowFiled">需要显示的字段，默认为*</param>
        /// <returns></returns>
        public string Select(string table_name, List<SQLRequirement> Requirement_list, string ShowFiled = "*")
        {
            string table_name_NoKey = MySQLKeyWordCancel(table_name);
            List<SQLRequirement> Requirement_list_NoKey = MySQLKeyWordCancelPlus(Requirement_list);

            DataTable datatable = dao.Select(table_name_NoKey, Requirement_list_NoKey, ShowFiled);
            return ObjToJSON.DataTableToJsonWithJavaScriptSerializer(datatable);//DataTable转为Json
        }
        /// <summary>
        /// 修改
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
            //由于此处list是引用类型，需序列化复制一个list的副本，否则会改变list，导致语句错误
            List<SQLRequirement> Requirement_list_NoKey = Requirement_list.Select(x => new SQLRequirement {
                Field = x.Field,
                Mode = x.Mode,
                Value =x.Value,
            }).ToList();
            foreach (SQLRequirement requirement in Requirement_list_NoKey)
            {
                requirement.Field = MySQLKeyWordCancel(requirement.Field);
                if ("like".Equals(requirement.Mode))
                    requirement.Value = "%" + requirement.Value + "%";
            }
            return Requirement_list_NoKey;
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