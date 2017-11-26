using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFrame.XUnit.Entity
{
    public class RoleInfo : BaseEntity<int>
    {

        public string RoleName { get; set; }

        public string Describe { get; set; }

        public bool IsActive { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}