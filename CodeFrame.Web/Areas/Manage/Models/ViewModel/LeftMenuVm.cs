using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFrame.Web.Areas.Manage.Models.ViewModel
{
    public class LeftMenuVm
    {
        public int id { get; set; }

        public string title { get; set; } = "";

        public string icon { get; set; } = "";

        public bool spread { get; set; }= true;

        public List<LeftMenuVm> children { get; set; } =new List<LeftMenuVm>();

        public string url { get; set; } = "";
    }
}
