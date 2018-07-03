using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFrame.Models.DbModel
{
    [Table("t_sysColumn")]
    public class Column : BaseEntity<int>
    {
        public int? TableId { get; set; }
        [ForeignKey("TableId")]
        //所属系统表
        public Table Table { get; set; }
        //显示名称
        [MaxLength(20)]
        public string ShowName { get; set; }
        //字段名称
        [MaxLength(30)]
        public string ColumnName { get; set; }
        //排序
        public int OrderBy { get; set; } = 0;
        //备注
        public string ReMark { get; set; }
        //提示
        [MaxLength(100)]
        public string Tip { get; set; }
        //是否显示
        public bool IsShow { get; set; } = true;
        //字段类型
        public int? ColumnType { get; set; }
        //显示控件
        public int ?DisplayType { get; set; }

        //外键表编号
        public int ?FkTableId { get; set; }

        public int? Width { get; set; }

        //作为查询条件
        public bool IsIndexed { get; set; } = true;
        [MaxLength(300)]
        public string DataOptions { get; set; }
    }
}
