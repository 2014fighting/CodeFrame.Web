using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFrame.XUnit.Entity
{
    public class UserRole :BaseEntity<int>
    {

        public int UserId { get; set; }
        public UserInfo UserInfo { get; set; }
        public int RoleId { get; set; }
        public RoleInfo RoleInfo { get; set; } = null;
    }
}
