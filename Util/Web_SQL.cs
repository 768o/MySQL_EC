using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MySQL_EC.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class Web_SQL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public static List<SQLRequirement> GetSelect(HttpRequestBase Request)
        {
            string[] searchField = Request.Params.GetValues("searchField");
            string[] mode = Request.Params.GetValues("mode");
            string[] key = Request.Params.GetValues("key");

            List<SQLRequirement> select = new List<SQLRequirement>();
            if (key != null)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    if (!IsNumeric(key[i])) {
                        key[i] = "'" + key[i] + "'";
                    }
                    SQLRequirement requirement = new SQLRequirement { Field = searchField[i], Mode = mode[i], Value = key[i] };
                    select.Add(requirement);
                }
            }

            return select;
        }
        private static bool IsNumeric(string str) //接收一个string类型的参数,保存到str里
        {
            if (str == null || str.Length == 0)    //验证这个参数是否为空
                return false;                           //是，就返回False
            ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的实例
            byte[] bytestr = ascii.GetBytes(str);         //把string类型的参数保存到数组里

            foreach (byte c in bytestr)                   //遍历这个数组里的内容
            {
                if (c < 48 || c > 57)                          //判断是否为数字
                {
                    return false;                              //不是，就返回False
                }
            }
            return true;                                        //是，就返回True
        }
    }
}
