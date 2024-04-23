using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
    public static class CommonUtils
    {
        public static string GetConnectionStr()
        {
            var conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            return conStr;
        }
    }
}
