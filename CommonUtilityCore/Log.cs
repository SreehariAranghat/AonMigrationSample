using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace CommonUtility
{
    public static class Log
    {
        private static readonly ILog log = LogManager.GetLogger("LibraryLogger");
        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Warn(string message) { 
            log.Warn(message);
        }

        public static void Error(string message) {
            log.Error(message);
        }
    }
}
