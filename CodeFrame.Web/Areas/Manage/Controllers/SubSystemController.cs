using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.Web.Areas.Manage.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeFrame.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class SubSystemController : Controller
    {
        #region Constructor
        private readonly ILogService<SubSystemController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SubSystemController(IUserInfoService userInfoService,
            IUnitOfWork unitOfWork, ILogService<SubSystemController> logger
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        #endregion
        [HttpGet]
        public ActionResult GetSubSystemlist()
        {
            var result = _unitOfWork.GetRepository<SubSystem>()
                .GetEntities().ProjectTo<SelectsModel>();
            return Json(result.ToList());
        }
        [HttpGet]
        public IActionResult GetAllSubSystem()
        {
            var result = from r in _unitOfWork.GetRepository<SubSystem>()
                    .GetEntities(i => i.IsActive)
                select new
                {
                    title = r.SystemName,
                    icon =r.SystemIcon,
                    id = r.Id
                };
            return Json(result);
        }
    }
}