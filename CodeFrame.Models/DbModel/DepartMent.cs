using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFrame.Models.DbModel
{
    [Table("t_sys_DepartMent")]
    public class DepartMent : BaseEntity<int>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(20)]
        public string DptName { get; set; }

        /// <summary>
        /// 上级部门
        /// </summary>
        public int  ParentId { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderBy { get; set; } = 0;

        /// <summary>
        /// 备注
        /// </summary>
        public string ReMark { get; set; }

        public List<UserInfo> UserInfos { get; set; }
    }
}
