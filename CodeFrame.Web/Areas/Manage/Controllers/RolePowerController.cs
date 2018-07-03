using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.Web.Areas.Manage.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses;

namespace CodeFrame.Web.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class RolePowerController : BaseController
    {
        #region Constructor
        private readonly ILogService<MenuController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RolePowerController(IUserInfoService userInfoService,
            IUnitOfWork unitOfWork, ILogService<MenuController> logger
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        #endregion
        /// <summary>
        /// 获取按钮权限根据菜单id和角色
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetBtnPowerByMenuId(int menuId)
        {
            var repRp=_unitOfWork.GetRepository<RolePower>();
            var repBtn = _unitOfWork.GetRepository<Button>();


            var menuButtons= repBtn.GetEntities(i => i.MenuId == menuId&&i.IsActive);
           var result=new List<ButtonPowerModel>();
            menuButtons.ToList().ForEach(i =>
            {
                result.Add(new ButtonPowerModel()
                {
                    BtnClass = i.BtnClass,
                    BtnName = i.BtnName,
                    BtnScript = i.BtnScript,
                    BtnIcon = i.BtnIcon,
                    BtnTip = i.BtnTip,
                    BtnUrl = i.BtnUrl,
                    HasAuthority = repRp.GetEntities().Any(
                        x => CurUserInfo.RoleList.Contains(x.RoleId)
                             && x.MenuId == menuId && x.ButtonId==i.Id),
                    IsActive = i.IsActive,
                    EditType = i.EditType,
                    BtnPosition=i.BtnPosition

                });
            });

              
            return Json(result);
           //todo 由于一个用户多个角色 所以这里可能要获取多个角色的按钮权限然后去除重复？

        }
    }
}