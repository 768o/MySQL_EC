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
            string sql = String.Format("{0}{1}{2}{3}{4}", "insert into ", table_name, "(" + filed + ") ", "value", "(" + value + ")");
            return MySqlHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
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
            StringBuilder sb = new StringBuilder();
            int list_count = Requirement_list.Count;
            foreach (SQLRequirement requirement in Requirement_list)
            {
               string requirement_str = String.Format("{0}{1}{2}{3}{4}", requirement.Field, requirement.Mode,
                    "'", requirement.Value, "'");
                sb.Append(requirement_str);
                if (list_count-- > 1)
                    sb.Append(" and ");
            }
            string sql = String.Format("{0}{1}{2}{3}{4}{5}", "select ", ShowFiled, " from ", table_name, " where ", sb);
            return MySqlHelper.ExecuteQuery(sql);
        }
        /// <summary>
        /// 数据库更新操作的实现类
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            throw new NotImplementedException();
        }

    }
}