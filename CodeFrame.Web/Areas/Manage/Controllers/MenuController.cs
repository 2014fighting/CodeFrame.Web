using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.Web.Areas.Manage.Models;
using CodeFrame.Web.Areas.Manage.Models.Common;
using CodeFrame.Web.Areas.Manage.Models.QueryModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeFrame.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class MenuController : BaseController
    {
        #region Constructor
        private readonly ILogService<MenuController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MenuController(IUserInfoService userInfoService,
            IUnitOfWork unitOfWork, ILogService<MenuController> logger
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        #endregion
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMenu(MenuModel model)
        {
            var res = new MgResult();
            if (!ModelState.IsValid)
            {
                res.Code = 110;
                res.Msg = "后端模型验证失败！";
                return Json(res);
            }
            var tempMenu = _mapper.Map<Menu>(model);

            var repoMenu = _unitOfWork.GetRepository<Menu>();
            tempMenu.CreateUser = CurUserInfo.TrueName;
            tempMenu.CreateUserId = CurUserInfo.UserId;
            tempMenu.CreateTime = DateTime.Now;
            repoMenu.Insert(tempMenu);
            var r = _unitOfWork.SaveChanges();

            res.Code = r > 0 ? 0 : 1;
            res.Msg = r > 0 ? "ok" : "SaveChanges失败！";
            return Json(res);
        }

        [HttpGet]
        public IActionResult AddMenu()
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
        public IActionResult EditMenu(int id, int type = 1)
        {
            ViewBag.pageType = type;

            var Menu = _unitOfWork.GetRepository<Menu>().Find(id);

            return View(_mapper.Map<MenuModel>(Menu));
        }

        [HttpPost]
        public IActionResult EditMenu(MenuModel model)
        {
            var res = new MgResult();
            if (!ModelState.IsValid)
            {
                res.Code = 110;
                res.Msg = "后端验证不通过！";
                return Json(res);
            }

            var Menu = _unitOfWork.GetRepository<Menu>().Find(model.Id);
            if (Menu == null)
            {
                res.Code = 120;
                res.Msg = "数据不存在！";
                return Json(res);
            }

            _mapper.Map(model, Menu);
            Menu.UpdateTime = DateTime.Now;
            Menu.UpdateUser = CurUserInfo.TrueName;
            Menu.UpdateUserId = CurUserInfo.UserId;
            var r = _unitOfWork.SaveChanges();

            res.Code = r > 0 ? 0 : 1;
            res.Msg = r > 0 ? "ok" : "SaveChanges失败！";
            return Json(res);
        }
        [HttpGet]
        public ActionResult GetMenu(MenuQueryModel menu)
        {
            var result = _unitOfWork.GetRepository<Menu>().GetEntities();
            if (!string.IsNullOrEmpty(menu.MenuName))
                result = result.Where(i => i.MenuName.Contains(menu.MenuName));
            var w1 = result.OrderByDescending(x => x.Id).Skip((menu.page - 1) * menu.limit).Take(menu.limit);
            return Json(new
            {
                code = 0,
                msg = "ok",
                count = result.Count(),
                data = w1.ToList()
            });

        }

        [HttpPost]
        public ActionResult MenuDelete(List<int> ids)
        {
            var result = _unitOfWork.GetRepository<Menu>();
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

        [HttpGet]
        public ActionResult GetMenulist()
        {
            var result = _unitOfWork.GetRepository<Menu>()
                .GetEntities().ProjectTo<SelectsModel>();
            return Json(result.ToList());
        }
    }
}