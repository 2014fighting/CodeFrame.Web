using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFrame.Web.Areas.Manage.Models.QueryModel
{
    public class BaseQuery
    {
        public int page { get; set; } = 1;
        public int limit { get; set; } = 10;
    }
}
