using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.UnitOfWork.PagedList;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeFrame.Web.Controllers
{
    public class AccountController : Controller
    {
        private ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoService _userInfoService;

        public AccountController(IUserInfoService userInfoService, IUnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _userInfoService = userInfoService;
            _logger = logger;

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IPagedList<UserInfo>> Getinfo()
        {
            return await _unitOfWork.GetRepository<UserInfo>().GetPagedListAsync();
        }
        [HttpGet]
        public  ActionResult GetUserInfo(int page =1, int limit = 10)
        {

            //var w = _unitOfWork.GetRepository<UserInfo>().GetPagedList(pageIndex:page-1,pageSize:limit);

            var result = _unitOfWork.GetRepository<UserInfo>().GetEntities();
            var w1 = result.Skip((page-1)*limit).Take(limit);
            return Json(new {
                code= 0,
                msg="ok",
                count= result.Count(),
                data= w1.ToList()
            } );
            
        }
        public ActionResult GridTest()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Login(string userName, string password, string returnUrl)
        {
            var user = _userInfoService.GetUserInfo(userName, password);
            if (user != null)
            {

                user.AuthenticationType = CookieAuthenticationDefaults.AuthenticationScheme;
                var identity = new ClaimsIdentity(user.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(returnUrl);
            }
            ViewBag.Errormessage = "登录失败，用户名密码不正确";
            return View();
        }

        [HttpGet]
        public  IActionResult  Login()
        {
            return View();
        }
    }
}