using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFrame.Web.Areas.Manage.Models.QueryModel
{
    public class UserInfoQueryModel:BaseQuery
    {
        public int? Id { get; set; }
        public string UserName { get; set; }

        public string TrueName { get; set; }

        public string Password { get; set; }

        public string PhoneNo { get; set; }
    }
}
