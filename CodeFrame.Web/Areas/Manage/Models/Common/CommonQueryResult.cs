using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFrame.Web.Areas.Manage.Models.Common
{
    public class CommonQueryResult
    {
        public int code { get; set; } = 0;
        public string msg { get; set; }
        public int count { get; set; } = 0;
        public object data { get; set; }
    }
}
