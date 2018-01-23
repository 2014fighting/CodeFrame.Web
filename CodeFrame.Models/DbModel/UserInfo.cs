using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace CodeFrame.Models.DbModel
{
    [Table("t_sys_UserInfo")]
    public class UserInfo : BaseEntity<int>
    {
        [MaxLength(20)]
        [Required]
        public string UserName { get; set; }

        [MaxLength(20)]
        [Required]
        public string TrueName { get; set; }

        [MaxLength(30)]
        [Required]
        public string Password { get; set; }

        [StringLength(11)]
        public string PhoneNo { get; set; }

        public bool IsActive { get; set; } = true;

        public List<UserRole> UserRoles { get; set; }

        /// <summary>
        /// 部门外键
        /// </summary>
        public  int ?DepartMentId { get; set; }

        [ForeignKey("DepartMentId")]
        public DepartMent DepartMent { get; set; }


    }
}
