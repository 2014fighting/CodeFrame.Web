using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Models.DbModel;

namespace CodeFrame.API.Model
{
    public class UserInfoModel
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
 
        public string TrueName { get; set; }
 
        public string Password { get; set; }
 
        public string PhoneNo { get; set; }

        public List<int> UserRoles { get; set; }
    }
}
