using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Models.DbModel;

namespace CodeFrame.Web.Areas.Manage.Models
{
    public class UserInfoModel
    {
        public int? Id { get; set; }
        public string UserName { get; set; }

        public string TrueName { get; set; }

        public string Password { get; set; }

        public string PhoneNo { get; set; }

        public bool IsActive { get; set; } = true;

        public int? DepartMentId { get; set; }

        public int? Gender { get; set; }

        public string Skill { get; set; }

        public string Post { get; set; }

        public string Group { get; set; }

        public string GroupNum { get; set; }

        public string Describe { get; set; }

        public string Picture { get; set; }


        public List<int> UserRoles { get; set; }
    }
}
