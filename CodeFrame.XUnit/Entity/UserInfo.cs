using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CodeFrame.XUnit.Entity
{
    public class UserInfo : BaseEntity<int>
    {

        public string UserName { get; set; }


        public string TrueName { get; set; }

        public string Password { get; set; }


        public string PhoneNo { get; set; }
 
        public List<UserRole> UserRoles { get; set; } = null;
    }
}
