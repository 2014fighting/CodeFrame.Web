using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Models.DbModel;

namespace CodeFrame.Web.Areas.Manage.Models
{
    public class MenuModel
    {
        public int? Id { get; set; }

        public string MenuName { get; set; }
   
        public int? ParentMenuId { get; set; }
 
        public int? SubSystemId { get; set; }
 
        public int? SysTableId { get; set; }
  
  
        public string MenuUrl { get; set; }
         
 
        public bool IsActive { get; set; } = true;
    }
}
