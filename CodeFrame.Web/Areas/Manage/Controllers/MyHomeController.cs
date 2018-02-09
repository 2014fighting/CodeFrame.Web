using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeFrame.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class MyHomeController : BaseController
    {
        #region Constructor
        private readonly ILogService<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public MyHomeController(IUnitOfWork unitOfWork, ILogService<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        #endregion
        public IActionResult Index()
        {
            var curUser = _unitOfWork.GetRepository<UserInfo>().Find(CurUserInfo.UserId);
            ViewBag.userid = curUser.Id;
            ViewBag.truename = curUser.TrueName;
            ViewBag.handimg = curUser.Picture;
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