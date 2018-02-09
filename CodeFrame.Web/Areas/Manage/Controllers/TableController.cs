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
    public class TableController : BaseController
    {
        #region Constructor
        private readonly ILogService<TableController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TableController(IUserInfoService userInfoService,
            IUnitOfWork unitOfWork, ILogService<TableController> logger
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
        public IActionResult AddTable(TableModel model)
        {
            var res = new MgResult();
            if (!ModelState.IsValid)
            {
                res.Code = 110;
                res.Msg = "后端模型验证失败！";
                return Json(res);
            }
            var table = _mapper.Map<Table>(model);

            var repoTable = _unitOfWork.GetRepository<Table>();
            table.CreateUser = CurUserInfo.TrueName;
            table.CreateUserId = CurUserInfo.UserId;
            table.CreateTime = DateTime.Now;
            repoTable.Insert(table);
            var r = _unitOfWork.SaveChanges();

            res.Code = r > 0 ? 0 : 1;
            res.Msg = r > 0 ? "ok" : "SaveChanges失败！";
            return Json(res);
        }

        [HttpGet]
        public IActionResult AddTable()
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
        public IActionResult EditTable(int id, int type = 1)
        {
            ViewBag.pageType = type;

            var table = _unitOfWork.GetRepository<Table>().Find(id);

            return View(_mapper.Map<TableModel>(table));
        }

        [HttpPost]
        public IActionResult EditTable(TableModel model)
        {
            var res = new MgResult();
            if (!ModelState.IsValid)
            {
                res.Code = 110;
                res.Msg = "后端验证不通过！";
                return Json(res);
            }

            var table = _unitOfWork.GetRepository<Table>().Find(model.Id);
            if (table == null)
            {
                res.Code = 120;
                res.Msg = "数据不存在！";
                return Json(res);
            }

            _mapper.Map(model, table);
            table.UpdateTime = DateTime.Now;
            table.UpdateUser = CurUserInfo.TrueName;
            table.UpdateUserId = CurUserInfo.UserId;
            var r = _unitOfWork.SaveChanges();

            res.Code = r > 0 ? 0 : 1;
            res.Msg = r > 0 ? "ok" : "SaveChanges失败！";
            return Json(res);
        }
        [HttpGet]
        public ActionResult GetTable(TableQueryModel model)
        {
            var result = _unitOfWork.GetRepository<Table>().GetEntities();
            if (!string.IsNullOrEmpty(model.TableName))
                result = result.Where(i => i.TableName.Contains(model.TableName));
            var w1 = result.OrderByDescending(x => x.Id).Skip((model.page - 1) * model.limit).Take(model.limit);
            return Json(new
            {
                code = 0,
                msg = "ok",
                count = result.Count(),
                data = w1.ToList()
            });

        }

        [HttpPost]
        public ActionResult TableDelete(List<int> ids)
        {
            var result = _unitOfWork.GetRepository<Table>();
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

        public IActionResult GetAllTable()
        {
            var result = _unitOfWork.GetRepository<Table>()
                .GetEntities().ProjectTo<SelectsModel>();
            return Json(result.ToList());
        }
    }
}