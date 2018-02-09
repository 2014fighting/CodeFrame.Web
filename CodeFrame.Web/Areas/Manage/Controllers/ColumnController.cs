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
    public class ColumnController : BaseController
    {
        #region Constructor
        private readonly ILogService<ColumnController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ColumnController(IUserInfoService userInfoService,
            IUnitOfWork unitOfWork, ILogService<ColumnController> logger
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
        public IActionResult AddColumn(ColumnModel model)
        {
            var res = new MgResult();
            if (!ModelState.IsValid)
            {
                res.Code = 110;
                res.Msg = "后端模型验证失败！";
                return Json(res);
            }
            var column = _mapper.Map<Column>(model);

            var repoColumn = _unitOfWork.GetRepository<Column>();
            column.CreateUser = CurUserInfo.TrueName;
            column.CreateUserId = CurUserInfo.UserId;
            column.CreateTime = DateTime.Now;
            repoColumn.Insert(column);
            var r = _unitOfWork.SaveChanges();

            res.Code = r > 0 ? 0 : 1;
            res.Msg = r > 0 ? "ok" : "SaveChanges失败！";
            return Json(res);
        }

        [HttpGet]
        public IActionResult AddColumn()
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
        public IActionResult EditColumn(int id, int type = 1)
        {
            ViewBag.pageType = type;

            var column = _unitOfWork.GetRepository<Column>().Find(id);

            return View(_mapper.Map<ColumnModel>(column));
        }

        [HttpPost]
        public IActionResult EditColumn(ColumnModel model)
        {
            var res = new MgResult();
            if (!ModelState.IsValid)
            {
                res.Code = 110;
                res.Msg = "后端验证不通过！";
                return Json(res);
            }

            var column = _unitOfWork.GetRepository<Column>().Find(model.Id);
            if (column == null)
            {
                res.Code = 120;
                res.Msg = "数据不存在！";
                return Json(res);
            }

            _mapper.Map(model, column);
            column.UpdateTime = DateTime.Now;
            column.UpdateUser = CurUserInfo.TrueName;
            column.UpdateUserId = CurUserInfo.UserId;
            var r = _unitOfWork.SaveChanges();

            res.Code = r > 0 ? 0 : 1;
            res.Msg = r > 0 ? "ok" : "SaveChanges失败！";
            return Json(res);
        }
        [HttpGet]
        public ActionResult GetColumn(ColumnQueryModel column)
        {
            var result = _unitOfWork.GetRepository<Column>().GetEntities();
            if (!string.IsNullOrEmpty(column.ColumnName))
                result = result.Where(i => i.ColumnName.Contains(column.ColumnName));
            var w1 = result.OrderByDescending(x => x.Id).Skip((column.page - 1) * column.limit).Take(column.limit);
            return Json(new
            {
                code = 0,
                msg = "ok",
                count = result.Count(),
                data = w1.ToList()
            });

        }

        [HttpPost]
        public ActionResult ColumnDelete(List<int> ids)
        {
            var result = _unitOfWork.GetRepository<Column>();
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