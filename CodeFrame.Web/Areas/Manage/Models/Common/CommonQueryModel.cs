using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFrame.Web.Areas.Manage.Models.Common
{
    public class CommonQueryModel
    {
        public int tableId { get; set; }
        public string filter { get; set; }
        public string where { get; set; }
        public int page { get; set; } = 1;
        public int limit { get; set; } = 10;
 
    }
}
