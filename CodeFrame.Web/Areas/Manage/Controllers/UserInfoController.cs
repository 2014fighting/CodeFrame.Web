using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.Web.Areas.Manage.Models;
using CodeFrame.Web.Areas.Manage.Models.Common;
using CodeFrame.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeFrame.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class UserInfoController : Controller
    {
        #region Constructor
        private readonly ILogService<UserInfoController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserInfoService _userInfoService;

        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UserInfoController(IUserInfoService userInfoService,
            IUnitOfWork unitOfWork, ILogService<UserInfoController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userInfoService = userInfoService;
            _logger = logger;
            _mapper = mapper;
        }

        #endregion

 
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _mapper.Map<UserInfo>(model);
            var repoUser = _unitOfWork.GetRepository<UserInfo>();
            //内存数据库无自增长
            user.Id = repoUser.GetEntities().OrderByDescending(i => i.Id).FirstOrDefault().Id+1;
            repoUser.Insert(user);

            var r = _unitOfWork.SaveChanges();

            //_userInfoService.AddUserInfo();
            return Json(new MgResult()
            {
                Code = r > 0 ? 0 : 1,
                Msg = r > 0 ? "ok" : "SaveChanges失败！"
            });
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type">1编辑 2查看</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditUser(int id,int type=1)
        {
            ViewBag.pageType = type;
            var repUser=_unitOfWork.GetRepository<UserInfo>();
            return View(_mapper.Map<UserInfoModel>(repUser.Find(id)));
        }

        [HttpPost]
        public IActionResult EditUser(UserInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _unitOfWork.GetRepository<UserInfo>().Find(model.Id);
            user.UpdateTime=DateTime.Now;
            _mapper.Map(model, user);
            
            var r = _unitOfWork.SaveChanges();
 
            return Json(new MgResult()
            {
                Code = r > 0 ? 0 : 1,
                Msg = r > 0 ? "ok" : "SaveChanges失败！"
            });
        }
        [HttpGet]
        public ActionResult GetUserInfo(UserInfoModel user, int page = 1, int limit = 10)
        {
            //var w = _unitOfWork.GetRepository<UserInfo>().GetPagedList(pageIndex:page-1,pageSize:limit);

            var result = _unitOfWork.GetRepository<UserInfo>().GetEntities();
            if (!string.IsNullOrEmpty(user.UserName))
                result = result.Where(i => i.UserName.Contains(user.UserName));
            if (!string.IsNullOrEmpty(user.PhoneNo))
                result = result.Where(i => i.PhoneNo.Contains(user.PhoneNo));
            if (!string.IsNullOrEmpty(user.TrueName))
                result = result.Where(i => i.TrueName.Contains(user.TrueName));
            var w1 = result.OrderByDescending(x => x.Id).Skip((page - 1) * limit).Take(limit);
            return Json(new
            {
                code = 0,
                msg = "ok",
                count = result.Count(),
                data = w1.ToList()
            });

        }

        [HttpPost]
        public ActionResult UserDelete(List<int> ids)
        {
            var result = _unitOfWork.GetRepository<UserInfo>();
            ids.ForEach(i =>
            {
                result.Delete(result.Find(i));
            });
            var r = _unitOfWork.SaveChanges() > 0;

            return Json(new MgResult
            {
                Code = r ? 0 : 1,
                Msg = r ? "ok" : "SaveChanges失败！"
            });
        }
    }
}