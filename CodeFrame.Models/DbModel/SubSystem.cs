using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFrame.Models.DbModel
{
    [Table("t_sysSubSystem")]
    public class SubSystem : BaseEntity<int>
    {
        public string SystemName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderBy { get; set; } = 0;
        /// <summary>
        /// 链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string SystemIcon { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string ReMark { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; } = true;

        public List<Menu> MenuInfo { get; set; }



    }
}
