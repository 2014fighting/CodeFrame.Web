using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Models.DbModel;

namespace CodeFrame.Web.Areas.Manage.Models
{
    public class ColumnModel
    {
        public int Id { get; set; }
        public int? TableId { get; set; }
       
        //显示名称
        public string ShowName { get; set; }
        //字段名称
        
        public string ColumnName { get; set; }
        //排序
        public int OrderBy { get; set; } = 0;
        //备注
        public string ReMark { get; set; }
        //提示
      
        public string Tip { get; set; }
        //是否显示
        public bool IsShow { get; set; } = true;
        //字段类型
        public int? ColumnType { get; set; }
        //显示控件
        public int? DisplayType { get; set; }
 

        public int? Width { get; set; }

        //作为查询条件
        public bool IsIndexed { get; set; } = true;
      
    }
}
