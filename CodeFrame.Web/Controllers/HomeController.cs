using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Common;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using CodeFrame.Web.Models;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CodeFrame.Web.Controllers
{
    public class HomeController : Controller
    {

        #region Constructor
        private readonly ILogService<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoService _userInfoService;

        public HomeController(IUserInfoService userInfoService, IUnitOfWork unitOfWork, ILogService<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _userInfoService = userInfoService;
            _logger = logger;
        }
        #endregion

        public IActionResult Index()
        {
            _logger.Info("握了个叉");
            _logger.Info("错误信息");

             _userInfoService.AddUserInfo();
            //var xuser = _unitOfWork.GetRepository<UserInfo>().
            //    GetPagedList(predicate: i => i.UserName.Contains("wenqing"), orderBy: sour => sour.OrderByDescending(i => i.Id));
            //var xuser = _unitOfWork.GetRepository<UserInfo>()
            //    .GetEntities(i => i.UserName.Contains("wenqing") && i.Password.Contains("12"));
           // ViewBag.username = xuser.Items.First().UserName;
            //var w= _unitOfWork.GetRepository<UserInfo>().GetPagedList();
            var w = _unitOfWork.GetRepository<UserInfo>().GetEntities().Take(10).ToList();
            return View();
        }
        [Authorize(Roles = "system")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "bos")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;
            _logger.Error(error);

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

 
    }
}
