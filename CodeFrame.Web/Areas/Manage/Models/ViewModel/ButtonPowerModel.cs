using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFrame.Web.Areas.Manage.Models.ViewModel
{
    public class ButtonPowerModel
    {
    
        public string BtnName { get; set; }
 
        public int MenuId { get; set; }

        public int EditType { get; set; }
        public string BtnUrl { get; set; }

        public bool HasAuthority { get; set; } = false;

        public int OrderBy { get; set; } = 0;
      
        public string BtnScript { get; set; }
         
        public string SpName { get; set; }
    
        public string BtnClass { get; set; }
       
        public string BtnIcon { get; set; }
   
        public string BtnTip { get; set; }
        
        public string DisplayCondition { get; set; }

        public bool IsActive { get; set; } = true;
     
        public bool IsSpecial { get; set; } = true;

        public int BtnPosition { get; set; } =1;
    }
}
