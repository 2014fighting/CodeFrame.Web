using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoService _userInfoService;
        private readonly ILog _log = LogManager.GetLogger(Startup.Repository.Name, typeof(HomeController));
        public HomeController(IUserInfoService userInfoService, IUnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _userInfoService = userInfoService;
            _logger = logger;
          
        }
       
        public IActionResult Index()
        {
            for (int i = 0; i < 10; i++)
            {
                _log.Info("··测试压测log测试压测log测试压测log测试压测log测试压测log测试压测log测试压测log测试压测log测试压测log··");
                _log.Error("··错误信息log错误信息log错误信息log错误信息log错误信息log错误信息log错误信息log错误信息log错误信息log··");
            }
            _log.Info("握了个叉");
            _log.Error("错误信息");
            _logger.LogInformation("gouzaohans");
            //_userInfoService.AddUserInfo();
            var xuser = _unitOfWork.GetRepository<UserInfo>().
                GetPagedList(predicate:x=>x.UserName.Contains("wenqing")
             &&x.Password.Contains("12")
            , orderBy: source => source.OrderBy(b => b.Id));
            ViewBag.username = xuser.Items.First().UserName;
           var w= _unitOfWork.GetRepository<UserInfo>().GetPagedList();
         

            // _logger.Log();
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
            _log.Error(error);
        
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
