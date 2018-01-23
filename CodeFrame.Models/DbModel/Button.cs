using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFrame.Models.DbModel
{
    [Table("t_sys_Button")]
    public  class Button : BaseEntity<int>
    {
        [MaxLength(20)]
        public string BtnName{ get; set; }


        /// <summary>
        /// 关联表
        /// </summary>
        public int SysTableId { get; set; }

        public Table Table { get; set; }
        [MaxLength(300)]
        public string BtnUrl { get; set; }

        public int EditType { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderBy { get; set; }
        [MaxLength(50)]
        public string BtnScript { get; set; }
        [MaxLength(50)]
        public string SpName { get; set; }
        [MaxLength(50)]
        public string BtnClass { get; set; }
        [MaxLength(50)]
        public string BtnIcon { get; set; }
        [MaxLength(50)]
        public string BtnTip { get; set; }
        [MaxLength(500)]
        public string DisplayCondition { get; set; }
 
        public bool IsActive { get; set; } = true;

    }
}
