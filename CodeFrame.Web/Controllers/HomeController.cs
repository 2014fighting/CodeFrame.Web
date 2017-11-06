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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CodeFrame.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoService _userInfoService;

        public HomeController(IUserInfoService userInfoService, IUnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _userInfoService = userInfoService;
            _logger = logger;
          
        }
        public IActionResult Index()
        {
            _logger.LogInformation("握了个叉");
            _userInfoService.AddUserInfo();
            var xuser = _unitOfWork.GetRepository<UserInfo>().
                GetPagedList(predicate:x=>x.UserName.Contains("wenqing")
             &&x.Password.Contains("12")
            , orderBy: source => source.OrderByDescending(b => b.Id));
            ViewBag.username = xuser.Items.First().UserName;
           var w= _unitOfWork.GetRepository<UserInfo>().GetPagedList();

         
           // _logger.Log();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
