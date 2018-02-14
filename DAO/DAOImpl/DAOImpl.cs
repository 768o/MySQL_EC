using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace MySQL_EC
{
    /// <summary>
    /// IDAO的实现类
    /// </summary>
    public class DAOImpl : IDAO
    {
        enum Types { Insert, Delete, Update, Select};
        /// <summary>
        /// 数据库插入操作的实现类
        /// </summary>
        /// <returns></returns>
        public int Insert(string table_name, List<SQLRequirement> Requirement_list)
        {
            StringBuilder filed = new StringBuilder();
            StringBuilder value = new StringBuilder();
            int list_count = Requirement_list.Count;
            foreach (SQLRequirement requirement in Requirement_list)
            {
                filed.Append(requirement.Field);
                value.Append(requirement.Value);
                if (list_count-- > 1)
                {
                    filed.Append(",");
                    value.Append(",");
                }
            }
            string sql = String.Format("{0}{1}{2}{3}{4}", GetOperaType(Types.Insert), table_name, "(" + filed + ") ", "values", "(" + value + ")");
            return MySqlHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Delete(string table_name, List<SQLRequirement> Requirement_list)
        {
            string where = GetRequirement(Requirement_list);
            string sql = String.Format("{0}{1}{2}", GetOperaType(Types.Delete), table_name, where);
            return MySqlHelper.ExecuteNonQuery(sql);
            throw new NotImplementedException();
        }
        /// <summary>
        /// 数据库查询操作的实现类
        /// </summary>
        /// <param name="table_name">数据库表名</param>
        /// <param name="Requirement_list">查询条件列表<seealso cref="MySQL_EC.SQLRequirement">见SQLRequirement类</seealso></param>
        /// <param name="ShowFiled">需要显示的字段</param>
        /// <returns>返回查询的结果DateTable</returns>
        public DataTable Select(string table_name, List<SQLRequirement> Requirement_list, string ShowFiled)
        {
            string where = GetRequirement(Requirement_list);
            string sql = String.Format("{0}{1}{2}", GetOperaType(Types.Select, ShowFiled) , table_name, where);
            return MySqlHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// 数据库更新操作的实现类
        /// </summary>
        /// <returns></returns>
        public int Update(string table_name, List<SQLRequirement> Set_list, List<SQLRequirement> Requirement_list)
        {
            string set = GetRequirement(Set_list, "set");
            string where = GetRequirement(Requirement_list);
            string sql = String.Format("{0}{1}{2}{3}", GetOperaType(Types.Update), table_name, set, where);
            return MySqlHelper.ExecuteNonQuery(sql);
            //update table set xxx == xxx where xxx=xxx;
        }
        /// <summary>
        /// 获得操作类型，几增删改查
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ShowFiled"></param>
        /// <returns></returns>
        private string GetOperaType(Types type,string ShowFiled = null) {
            string OperaType = null;
            switch (type) {
                case Types.Insert:
                    OperaType = "insert into ";
                    break;
                case Types.Delete:
                    OperaType = "delete from";
                    break;
                case Types.Update:
                    OperaType = "update ";
                    break;
                case Types.Select:
                    OperaType = "select " + ShowFiled + " from ";
                    break;
                default:
                    break;
            }
            return OperaType;
        }
        /// <summary>
        /// 获得更新，查询，删除的where or set字符串
        /// </summary>
        /// <param name="Requirement_list"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetRequirement(List<SQLRequirement> Requirement_list, string s = "where") {
            StringBuilder sb = new StringBuilder();
            s = " " + s + " ";
            sb.Append(s);
            int list_count = Requirement_list.Count;
            foreach (SQLRequirement requirement in Requirement_list)
            {
                string requirement_str = String.Format("{0}{1}{2}{3}{4}", requirement.Field, requirement.Mode,
                     " '", requirement.Value, "' ");
                sb.Append(requirement_str);
                if (list_count-- > 1)
                    sb.Append(" and ");
            }
            return sb.ToString();
        }
    }
}