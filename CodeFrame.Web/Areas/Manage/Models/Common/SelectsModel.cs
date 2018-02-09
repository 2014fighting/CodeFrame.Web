using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFrame.Web.Areas.Manage.Models.Common
{
    public class SelectsModel
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class SelectGroup
    {
        public string Group { get; set; }
        public List<SelectsModel> SelectsModel { get; set; }
    }
}
