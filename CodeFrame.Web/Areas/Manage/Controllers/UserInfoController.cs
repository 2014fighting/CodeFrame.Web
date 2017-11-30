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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeFrame.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class UserInfoController : Controller
    {
        private ILogger<UserInfoController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoService _userInfoService;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public UserInfoController(IUserInfoService userInfoService, 
            IUnitOfWork unitOfWork, ILogger<UserInfoController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userInfoService = userInfoService;
            _logger = logger;
            _mapper = mapper;
        }
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
            repoUser.Insert(user);

            var r = _unitOfWork.SaveChanges();
            return Json(new MgResult()
            {
                Code = r>0?0 : 1,
                Msg = r>0? "ok" : "SaveChanges失败！"
            });
        }
        [HttpGet]
        public IActionResult AddUser()
        {
                return View();
        }

        [HttpGet]
        public ActionResult GetUserInfo(UserInfoModel user,int page = 1, int limit = 10)
        {
            //var w = _unitOfWork.GetRepository<UserInfo>().GetPagedList(pageIndex:page-1,pageSize:limit);

            var result = _unitOfWork.GetRepository<UserInfo>().GetEntities();
            if (!string.IsNullOrEmpty(user.UserName))
                result = result.Where(i => i.UserName.Contains(user.UserName));
            if (!string.IsNullOrEmpty(user.PhoneNo))
                result = result.Where(i => i.UserName.Contains(user.PhoneNo));
            if (!string.IsNullOrEmpty(user.TrueName))
                result = result.Where(i => i.UserName.Contains(user.TrueName));
            var w1 = result.OrderByDescending(x=>x.Id).Skip((page - 1) * limit).Take(limit);
            return Json(new
            {
                code = 0,
                msg = "ok",
                count = result.Count(),
                data = w1.ToList()
            });

        }

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