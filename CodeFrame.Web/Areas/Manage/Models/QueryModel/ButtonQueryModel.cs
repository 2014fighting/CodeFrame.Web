using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Models.DbModel;

namespace CodeFrame.Web.Areas.Manage.Models.QueryModel
{
    public class ButtonQueryModel: BaseQuery
    {
        [MaxLength(20)]
        public string BtnName { get; set; }

         
 
    }
}
