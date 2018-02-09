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
    public class DepartMentController : Controller
    {
        #region Constructor
        private readonly ILogService<DepartMentController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        public DepartMentController(IUnitOfWork unitOfWork, ILogService<DepartMentController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetDpList()
        {
            var result = _unitOfWork.GetRepository<DepartMent>()
                .GetEntities().ProjectTo<SelectsModel>();
            return Json(result.ToList());
        }
    }
}