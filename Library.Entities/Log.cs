using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Log : BaseObject
    {
        public string Message { get; set; }

        public string User    { get; set; }
    }
}
