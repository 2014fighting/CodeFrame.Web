using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CodeFrame.Common;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.UnitOfWork.PagedList;
using log4net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeFrame.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Constructor
        private readonly ILogService _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoService _userInfoService;
        //private readonly ILog _log = LogManager.GetLogger(Startup.Repository..Name, typeof(AccountController));
        public AccountController(IUserInfoService userInfoService, IUnitOfWork unitOfWork, ILogService logger)
        {
            _unitOfWork = unitOfWork;
            _userInfoService = userInfoService;
            _logger = logger;
        } 
        #endregion

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
        public async Task<IActionResult> Login(string userName, string password, string returnUrl)
        {
          
            var user = _userInfoService.GetUserInfo(userName, password);
            if (user != null)
            {

                //创建一个基于声明的授权方案
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
 
                //可多个Claim构成一个用户的身份
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                //用户所有角色 分别一个claim
                user.UserRoles.ForEach(i =>
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, i.RoleInfo.RoleName));
                });

                // 将用户身份信息写入到响应cookie中 ，[Authorize]
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                _logger.Info($"{user.UserName}用户登入~");
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "MyHome", new { area ="Manage" });
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
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.Info("当前用户退出~");
           return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}