using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MySQL_EC
{
    /// <summary> IDAO的实现类，实现增删改查等功能 </summary>
    public class DAOImpl : IDAO
    {
        /// <summary> 枚举，增删改查 </summary>
        enum Types { Insert, Delete, Update, Select};

        /// <summary> 数据库插入操作的实现类 </summary>
        /// <param name="table_name">表名</param>
        /// <param name="Requirement_list"> 操作的数据(where) </param>
        /// <returns>影响的行数</returns>
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

        /// <summary> 数据库删除操作的实现类 </summary>
        /// <param name="table_name"> 表名 </param>
        /// <param name="Requirement_list"> 操作的数据(where) </param>
        /// <returns> 影响的行数 </returns>
        public int Delete(string table_name, List<SQLRequirement> Requirement_list)
        {
            string where = GetRequirement(Requirement_list);
            string sql = String.Format("{0}{1}{2}", GetOperaType(Types.Delete), table_name, where);
            return MySqlHelper.ExecuteNonQuery(sql);
            throw new NotImplementedException();
        }

        /// <summary> 数据库查询操作的实现类 </summary>
        /// <param name="table_name">表名</param>
        /// <param name="Requirement_list"> 操作的数据(where) </param>
        /// <param name="ShowFiled"> 需要显示的字段 </param>
        /// <returns> 查询的结果 </returns>
        public DataTable Select(string table_name, List<SQLRequirement> Requirement_list, string ShowFiled)
        {
            string where = GetRequirement(Requirement_list);
            string sql = String.Format("{0}{1}{2}", GetOperaType(Types.Select, ShowFiled) , table_name, where);
            return MySqlHelper.ExecuteQuery(sql);
        }

        /// <summary> 数据库更新操作的实现类 </summary>
        /// <param name="table_name"> 表名 </param>
        /// <param name="Set_list"> 操作的数据(set) </param>
        /// <param name="Requirement_list"> 操作的数据(where) </param>
        /// <returns> 影响的行数 </returns>
        public int Update(string table_name, List<SQLRequirement> Set_list, List<SQLRequirement> Requirement_list)
        {
            string set = GetRequirement(Set_list, "set");
            string where = GetRequirement(Requirement_list);
            string sql = String.Format("{0}{1}{2}{3}", GetOperaType(Types.Update), table_name, set, where);
            return MySqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary> 获得操作类型，增删改查 </summary>
        /// <param name="type"> 增删改查 </param>
        /// <param name="ShowFiled"> 需要显示的字段 </param>
        /// <returns> 字符串，操作类型 </returns>
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
        /// <summary> 获得更新，查询，删除的where or set字符串 </summary>
        /// <param name="Requirement_list"> 操作的数据(whereorset) </param>
        /// <param name="whereorset"> 数据的位置whereorset </param>
        /// <returns> 拼接之后的set，where语句 </returns>
        private string GetRequirement(List<SQLRequirement> Requirement_list, string whereorset = "where") {
            StringBuilder sb = new StringBuilder();
            whereorset = " " + whereorset + " ";
            sb.Append(whereorset);
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