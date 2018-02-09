using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFrame.Web.Areas.Manage.Models.QueryModel
{
    public class RoleInfoQueryModel:BaseQuery
    {
        public string RoleName { get; set; }

        public string Describe { get; set; }
    }
}
