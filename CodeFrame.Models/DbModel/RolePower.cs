using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFrame.Models.DbModel
{
    [Table("t_sysRolePower")]
    public class RolePower : BaseEntity<int>
    {
        public int ButtonId { get; set; }

        public int RoleId { get; set; }

        public int MenuId { get; set; }

        public int Type { get; set; }
    }
}
