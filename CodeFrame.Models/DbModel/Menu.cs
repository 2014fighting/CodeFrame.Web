using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFrame.Models.DbModel
{
    [Table("t_sys_MenuInfo")]
    public class Menu : BaseEntity<int>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [MaxLength(20)]
        public string MenuName { get; set; }
         /// <summary>
         /// 父菜单
         /// </summary>
        public int? ParentMenuId { get; set; }

        /// <summary>
        /// 子系统id
        /// </summary>
        public int ?SubSystemId { get; set; }
        public SubSystem SubSystem { get; set; }
        /// <summary>
        /// 关联表
        /// </summary>
        public int ?SysTableId { get; set; }
        public Table Table { get; set; }
        /// <summary>
        /// 菜单URL
        /// </summary>
        [MaxLength(500)]
        public string MenuUrl { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderBy { get; set; } = 0;

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; } = true;

    }
}
