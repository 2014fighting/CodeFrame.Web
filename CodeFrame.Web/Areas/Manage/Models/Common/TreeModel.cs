using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFrame.Web.Areas.Manage.Models.Common
{
    public class TreeModel
    {
        public string id { get; set; }

        public string name { get; set; }

        public string pId { get; set; }

        public bool @checked{ get; set; }
    }
}
