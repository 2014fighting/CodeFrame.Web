using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Common;
using CodeFrame.Common.Definitions;
using Microsoft.AspNetCore.Mvc;

namespace CodeFrame.Web.Areas.Manage.Controllers
{
    public class BaseController : Controller
    {
        public UserSession CurUserInfo
        {
            get
            {
                if (HttpContext != null)
                    return new UserSession(HttpContext.User);
                else
                    return new UserSession();
            }
        }
    }
}