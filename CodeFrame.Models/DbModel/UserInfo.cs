using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace CodeFrame.Models.DbModel
{
    [Table("t_sysUserInfo")]
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
        public int? DepartMentId { get; set; }

        [ForeignKey("DepartMentId")]
        public DepartMent DepartMent { get; set; }

        public int? Gender { get; set; }

        /// <summary>
        /// 集团短号
        /// </summary>
        [MaxLength(100)]
        public string GroupNum { get; set; }

        [MaxLength(100)]
        public string Skill { get; set; }

        [MaxLength(500)]
        public string Describe { get; set; }

        [MaxLength(300)]
        public string Picture { get; set; }

        [MaxLength(300)]
        public string Post { get; set; }

        [MaxLength(100)]
        public string Group { get; set; }



    }
}
