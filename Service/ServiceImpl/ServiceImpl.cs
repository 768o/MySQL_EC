using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MySQL_EC
{
    /// <summary> IService的实现类，确保传入数据与传出数据的规范 </summary>
    public class ServiceImpl : IService
    {
        IDAO dao = new DAOImpl();

        /// <summary> 删除 </summary>
        /// <param name="table_name"> 表名 </param>
        /// <param name="Requirement_list"> 操作的数据(where) </param>
        /// <returns> 影响的行数 </returns>
        public int Delete(string table_name, List<SQLRequirement> Requirement_list)
        {
            string table_name_NoKey = MySQLKeyWordCancel(table_name);
            List<SQLRequirement> Requirement_list_NoKey = MySQLKeyWordCancelPlus(Requirement_list);

            return dao.Delete(table_name_NoKey, Requirement_list_NoKey);
        }

        /// <summary> 插入 </summary>
        /// <param name="table_name"> 表名 </param>
        /// <param name="Requirement_list"> 操作的数据(where) </param>
        /// <returns> 影响的行数 </returns>
        public int Insert(string table_name, List<SQLRequirement> Requirement_list)
        {
            string table_name_NoKey = MySQLKeyWordCancel(table_name);
            List<SQLRequirement> Requirement_list_NoKey = MySQLKeyWordCancelPlus(Requirement_list);

            return dao.Insert(table_name_NoKey, Requirement_list_NoKey);
        }

        /// <summary> 查询 </summary>
        /// <param name="table_name"> 表名 </param>
        /// <param name="Requirement_list"> 条件 </param>
        /// <param name="ShowFiled"> 需要显示的字段，默认为* </param>
        /// <param name="Sort"> 排序 </param>
        /// <returns> 查询的结果，json </returns>
        public string Select(string table_name, List<SQLRequirement> Requirement_list, string Sort, string ShowFiled = "*" )
        {
            DataTable datatable = SelectToDateTable(table_name, Requirement_list, Sort, ShowFiled);
            return ObjToJSON.DataTableToJsonWithJavaScriptSerializer(datatable);//DataTable转为Json
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="Requirement_list"></param>
        /// <param name="Sort"></param>
        /// <param name="ShowFiled"></param>
        /// <returns></returns>
        public DataTable SelectToDateTable(string table_name, List<SQLRequirement> Requirement_list, string Sort, string ShowFiled = "*")
        {
            string table_name_NoKey = MySQLKeyWordCancel(table_name);
            List<SQLRequirement> Requirement_list_NoKey = MySQLKeyWordCancelPlus(Requirement_list);
            string ShowFiled_NoKey = "*".Equals(ShowFiled) ? "*" : MySQLKeyWordCancelPlus(ShowFiled);

            DataTable datatable = dao.Select(table_name_NoKey, Requirement_list_NoKey, ShowFiled_NoKey);
            if (Sort != null)
            {
                datatable.DefaultView.Sort = Sort;
                datatable = datatable.DefaultView.ToTable();
            }
            return datatable;
        }
        
        /// <summary> 更新 </summary>
        /// <param name="table_name"> 表名 </param>
        /// <param name="Set_list"> 操作的数据(set) </param>
        /// <param name="Requirement_list"> 操作的数据(where) </param>
        /// <returns> 影响的行数 </returns>
        public int Update(string table_name, List<SQLRequirement> Set_list, List<SQLRequirement> Requirement_list)
        {
            string table_name_NoKey = MySQLKeyWordCancel(table_name);
            List<SQLRequirement> Set_list_NoKey = MySQLKeyWordCancelPlus(Set_list);
            List<SQLRequirement> Requirement_list_NoKey = MySQLKeyWordCancelPlus(Requirement_list);

            return dao.Update(table_name_NoKey, Set_list_NoKey, Requirement_list_NoKey);
        }

        /// <summary> 避免你的字符是MySQL关键字 </summary>
        /// <param name="Requirement_list"> 操作的数据(whereorset) </param>
        /// <returns> 没有关键字的字符串 </returns>
        private List<SQLRequirement> MySQLKeyWordCancelPlus(List<SQLRequirement> Requirement_list)
        {
            List<SQLRequirement> Requirement_list_NoKey = null;
            //由于此处list是引用类型，需序列化复制一个list的副本，否则会改变原list，导致后续错误
            if (Requirement_list != null)
            { 
                Requirement_list_NoKey = Requirement_list.Select(x => new SQLRequirement {
                    Field = x.Field, Mode = x.Mode, Value =x.Value,
                }).ToList();
                foreach (SQLRequirement requirement in Requirement_list_NoKey)
                {
                   requirement.Field = MySQLKeyWordCancel(requirement.Field);
                   if ("like".Equals(requirement.Mode))
                      requirement.Value = "%" + requirement.Value + "%";
                }
            }
            return Requirement_list_NoKey;
        }

        /// <summary> 避免你的字符是MySQL关键字 </summary>
        /// <param name="ShowFiled"> 显示的字段 </param>
        /// <returns> 没有关键字的字符串 </returns>
        private string MySQLKeyWordCancelPlus(string ShowFiled)
        {
            return "`" + ShowFiled.Replace(",", "`,`") + "`";
        }

        /// <summary> 避免你的字符是MySQL关键字 </summary>
        /// <param name="MaybeMySQLKeyWord">可能是关键字的字符串</param>
        /// <returns> 没有关键字的字符串 </returns>
        private string MySQLKeyWordCancel(string MaybeMySQLKeyWord)
        {
            return " `"+ MaybeMySQLKeyWord + "` ";
        }
    }
}