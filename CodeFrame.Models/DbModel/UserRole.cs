using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFrame.Models.DbModel
{ 
    [Table("t_sysUserRole")]
    public class UserRole 
    {
        public int UserId { get; set; }
        public UserInfo UserInfo { get; set; }
        public int RoleId { get; set; }
        public RoleInfo RoleInfo { get; set; }
    }
}
