using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFrame.Models.DbModel
{
    [Table("t_sysTable")]
    public class Table : BaseEntity<int>
    {
        public string TableName { get; set; }
        public string ShowName { get; set; }

        public bool IsMultiple { get; set; }

        public string ReMark { get; set; }

        public int OrderBy { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        public bool IsPaging { get; set; } = true;

        public List<Column> Columns { get; set; }
    }
}
