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
using CodeFrame.Web.Areas.Manage.Models.QueryModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeFrame.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class ButtonController : BaseController
    {
        #region Constructor
        private readonly ILogService<ButtonController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ButtonController(IUserInfoService userInfoService,
            IUnitOfWork unitOfWork, ILogService<ButtonController> logger
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
        public IActionResult AddButton(ButtonModel model)
        {
            var res = new MgResult();
            if (!ModelState.IsValid)
            {
                res.Code = 110;
                res.Msg = "后端模型验证失败！";
                return Json(res);
            }
            var button = _mapper.Map<Button>(model);
            var repoButton = _unitOfWork.GetRepository<Button>();
            button.CreateUser = CurUserInfo.TrueName;
            button.CreateUserId = CurUserInfo.UserId;
            button.CreateTime = DateTime.Now;
            repoButton.Insert(button);
            var r = _unitOfWork.SaveChanges();

            res.Code = r > 0 ? 0 : 1;
            res.Msg = r > 0 ? "ok" : "SaveChanges失败！";
            return Json(res);
        }

        [HttpGet]
        public IActionResult AddButton()
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
        public IActionResult EditButton(int id, int type = 1)
        {
            ViewBag.pageType = type;

            var button = _unitOfWork.GetRepository<Button>().Find(id);

            return View(_mapper.Map<ButtonModel>(button));
        }

        [HttpPost]
        public IActionResult EditButton(ButtonModel model)
        {
            var res = new MgResult();
            if (!ModelState.IsValid)
            {
                res.Code = 110;
                res.Msg = "后端验证不通过！";
                return Json(res);
            }

            var button = _unitOfWork.GetRepository<Button>().Find(model.Id);
            if (button == null)
            {
                res.Code = 120;
                res.Msg = "数据不存在！";
                return Json(res);
            }

            _mapper.Map(model, button);
            button.UpdateTime = DateTime.Now;
            button.UpdateUser = CurUserInfo.TrueName;
            button.UpdateUserId = CurUserInfo.UserId;
            var r = _unitOfWork.SaveChanges();

            res.Code = r > 0 ? 0 : 1;
            res.Msg = r > 0 ? "ok" : "SaveChanges失败！";
            return Json(res);
        }
        [HttpGet]
        public ActionResult GetButton(ButtonQueryModel button)
        {
            var result = _unitOfWork.GetRepository<Button>().GetEntities();
            if (!string.IsNullOrEmpty(button.BtnName))
                result = result.Where(i => i.BtnName.Contains(button.BtnName));
            var w1 = result.OrderByDescending(x => x.Id).Skip((button.page - 1) * button.limit).Take(button.limit);
            return Json(new
            {
                code = 0,
                msg = "ok",
                count = result.Count(),
                data = w1.ToList()
            });

        }

        [HttpPost]
        public ActionResult ButtonDelete(List<int> ids)
        {
            var result = _unitOfWork.GetRepository<Button>();
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