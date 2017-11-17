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
        private readonly ILogger<HomeController> _wlogger;

        private readonly ILogService _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoService _userInfoService;
    
        public HomeController(ILogger<HomeController> wlogger,IUserInfoService userInfoService, IUnitOfWork unitOfWork, ILogService logger)
        {
            _unitOfWork = unitOfWork;
            _userInfoService = userInfoService;
            _logger = logger;
            _wlogger = wlogger;
        }
       
        public IActionResult Index()
        {

            _logger.Info("握了个叉");
            _logger.Info("错误信息");
  
            //_userInfoService.AddUserInfo();
            var xuser = _unitOfWork.GetRepository<UserInfo>().
                GetPagedList(predicate:x=>x.UserName.Contains("wenqing")
             &&x.Password.Contains("12")
            , orderBy: source => source.OrderBy(b => b.Id));
            ViewBag.username = xuser.Items.First().UserName;
           var w= _unitOfWork.GetRepository<UserInfo>().GetPagedList();
 
            return View();
        }
        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Authorize]
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
