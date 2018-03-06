using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_EC.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceSingle
    {
        private static IService service;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IService GetService() {
            if (service == null) {
                service = new ServiceImpl();
            }
            return service;
        }
    }
}
