using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.Web.Areas.Manage.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodeFrame.Web.Areas.Manage.Controllers
{
    public class SysGridController : BaseController
    {
        #region Constructor
        private readonly ILogService<SysGridController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SysGridController(IUnitOfWork unitOfWork, ILogService<SysGridController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        #endregion
        public IActionResult DataGridIndex(int tableId)
        {
            return View();
        }

        public IActionResult GetGridData(CommonQueryModel quereyModel)
        {
            string tablename = "Table";
            var table = _unitOfWork.GetRepository<Table>().Find(quereyModel.tableId);
            var filter = new FilterGroup();

            if (!string.IsNullOrEmpty(quereyModel.where))
            {
                quereyModel.where = HttpUtility.UrlDecode(quereyModel.where);
                //反序列化Filter Group JSON
                 filter =  JsonConvert.DeserializeObject<FilterGroup>(quereyModel.where);
            }
            //var tn = typeof(table.TableName)
            //_unitOfWork.GetRepository<>().get
            //filter.rules?.ToList().ForEach(i =>
            //{
            //    i.field
            //});

            /*
            * where 为 json参数，格式如下： 
            * {
                 "roles":[
                    {"field":"ID","value":112,"op":"equal"},
                     {"field":"Time","value":"2011-3-4","op":"greaterorequal"}
                  ],
                 "op":"and","groups":null
            *  }
            */
            return Json("ok");
        }
    }
}