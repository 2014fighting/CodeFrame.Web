using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeFrame.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class MyHomeController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.userid = CurUserInfo.UserId;
            ViewBag.truename = CurUserInfo.TrueName;
            ViewBag.userid = CurUserInfo.RoleList;
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult MainPage()
        {
            return View();
        }

        public ActionResult MainPage1()
        {
            return View();
        }
    }
}