using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Models.DbModel;

namespace CodeFrame.Web.Areas.Manage.Models.QueryModel
{
    public class TableQueryModel:BaseQuery
    {
          public string TableName { get; set; }
    }
}
