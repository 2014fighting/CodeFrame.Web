using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFrame.Web.Areas.Manage.Models.Common
{
    /// <summary>
    /// 对应前台 ligerFilter 的检索规则数据
    /// </summary>
    [Serializable]
    public class FilterGroup
    {
        public IList<FilterRule> rules { get; set; }
        public string op { get; set; }
        public IList<FilterGroup> groups { get; set; }
    }
}
