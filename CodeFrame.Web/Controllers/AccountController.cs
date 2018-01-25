using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CodeFrame.Common;
using CodeFrame.Common.Definitions;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.UnitOfWork.PagedList;
using CodeFrame.Web.Areas.Manage.Models.Common;
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
        private readonly ILogService<AccountController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoService _userInfoService;
        //private readonly ILog _log = LogManager.GetLogger(Startup.Repository..Name, typeof(AccountController));
        public AccountController(IUserInfoService userInfoService, IUnitOfWork unitOfWork, ILogService<AccountController> logger)
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
        public async Task<IActionResult> Login(string username, string password, string returnUrl,bool remember=false)
        {
            var loginR = new MgResult();
            var user = _userInfoService.GetUserInfo(username, password);
            if (user != null)
            {

                //创建一个基于声明的授权方案
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
 
                //可多个Claim构成一个用户的身份
                identity.AddClaim(new Claim(MyClaimTypes.UserId, user.Id.ToString()));
                identity.AddClaim(new Claim(MyClaimTypes.UserName, user.UserName));
                identity.AddClaim(new Claim(MyClaimTypes.TrueName, user.TrueName));
                //用户所有角色 分别一个claim
                user.UserRoles.ForEach(i =>
                {
                    identity.AddClaim(new Claim(MyClaimTypes.Role, i.RoleInfo.RoleName));
                });
                
                // 将用户身份信息写入到响应cookie中 ，[Authorize]
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
                _logger.Info($"{user.UserName}用户登入~");
                loginR.Code = 0;
                loginR.Msg = "ok";
                return Json(loginR);

            }
            loginR.Code = 110;
            loginR.Msg = "用户名或密码错误!";
            return Json(loginR);
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