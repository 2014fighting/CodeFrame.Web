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
using CodeFrame.Web.Areas.Manage.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            tempMenu.MenuIcon = model.MenuIcon ?? "&#xe63c;";
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
        [HttpGet]
        public IActionResult GetAllMenuAndButton(int roleId)
        {
            //todo 
            var menus = _unitOfWork.GetRepository<Menu>().GetEntities();
            var rps = _unitOfWork.GetRepository<RolePower>().GetEntities();
            var listr = rps.Where(x => x.RoleId == roleId).Select(i => i.MentId);
           
            var subsystems = _unitOfWork.GetRepository<SubSystem>().GetEntities();
         
            var buttons = _unitOfWork.GetRepository<Button>().GetEntities();
            List<TreeModel> treeModels = new List<TreeModel>();
            foreach (var sub in subsystems)
            {
                treeModels.Add(new TreeModel { id = "a"+sub.Id, name = sub.SystemName, pId = "#"
                    ,@checked= menus.Any(i => listr.Contains(i.Id)&&sub.Id==i.SubSystemId)
            });
            }
        
            foreach (var menu in menus)
            {
                treeModels.Add(new TreeModel { id = "b"+menu.Id,
                    name = menu.MenuName,
                    pId = menu.ParentMenuId == null ? "a" + menu.SubSystemId: "b" + menu.ParentMenuId,
                    @checked = rps.Any(i => i.MentId == menu.Id && i.RoleId == roleId)
                });
            }

            foreach (var btn in buttons)
            {
                treeModels.Add(new TreeModel
                {
                    id = "c" + btn.Id,
                    name = btn.BtnName,
                    pId = "b" +btn.MenuId
                    ,@checked= rps.Any(i=>i.ButtonId==btn.Id&&i.RoleId==roleId)
                });
            }
            return Json(treeModels);
        }


        public IActionResult UpdateRolePower(int roleId, string powerString)
        {
            var rolepower = _unitOfWork.GetRepository<RolePower>();
            var res = new MgResult();
            if (roleId <= 0 || string.IsNullOrEmpty(powerString))
            {
                res.Code = 1;
                res.Msg = "参数有误！";
                return Json(res);
            }
           
            IList<TreeModel> pList = JsonConvert.DeserializeObject<IList<TreeModel>>(powerString);
            if (!pList.Any())
            {
                res.Code = 1;
                res.Msg = "没有任何需要变更的权限！";
                return Json(res);
            }
            rolepower.Delete(rolepower.GetEntities(i=>i.RoleId==roleId));
            var listrp=new List<RolePower>();
            foreach (var p in pList)
            {
                var rp = new RolePower();
                var strtemp = p.id.Substring(0, 1);
                if (strtemp == "b")
                {
                    rp.ButtonId =0;
                    rp.CreateTime = DateTime.Now;
                    rp.CreateUser = CurUserInfo.UserName;
                    rp.CreateUserId = CurUserInfo.UserId;
                    rp.MentId = Convert.ToInt32(p.id.TrimStart('b'));
                    rp.RoleId = roleId;
                }
                else
                {
                    rp.ButtonId = Convert.ToInt32(p.id.TrimStart('c'));
                    rp.CreateTime = DateTime.Now;
                    rp.CreateUser = CurUserInfo.UserName;
                    rp.CreateUserId = CurUserInfo.UserId;
                    rp.MentId = Convert.ToInt32(p.pId.TrimStart('b'));
                    rp.RoleId = roleId;
                }
                listrp.Add(rp);
            }
            rolepower.Insert(listrp);
           var r= _unitOfWork.SaveChanges();
            res.Code = r > 0 ? 0 : 1;
            res.Msg = r > 0 ? "ok" : "SaveChanges失败！";
            return Json(res);
        }


        /// <summary>
        /// 根据子系统获取相应的菜单列表
        /// </summary>
        /// <returns></returns>
        public  IActionResult GetMenuBySubsystem(int subId)
        {
            
              var result =   _unitOfWork.GetRepository<Menu>().GetEntities(i=>i.SubSystemId==subId);

            var allMenuList = result.ToList();
           var rootNodeList = new List<LeftMenuVm>();
            foreach (var parentNodeList in allMenuList.Where(t => t.ParentMenuId == null))
            {
                var menuNode = new LeftMenuVm();
                menuNode.id = parentNodeList.Id;
                menuNode.title = parentNodeList.MenuName??"";
                menuNode.url = parentNodeList.MenuUrl??"";
                menuNode.icon =parentNodeList.MenuIcon??"";
                menuNode.children = CreateChildTree(allMenuList, menuNode);
                rootNodeList.Add(menuNode);
            }
         
            return  Json(rootNodeList);
        }

        /// <summary>
        /// 递归生成子树
        /// </summary>
        /// <param name="allMenuList"></param>
        /// <param name="vmMenu"></param>
        /// <returns></returns>
        private List<LeftMenuVm> CreateChildTree(List<Menu> allMenuList, LeftMenuVm vmMenu)
        {
            var parentMenuId = vmMenu.id;//根节点ID
            List<LeftMenuVm> nodeList = new List<LeftMenuVm>();
            var children = allMenuList.Where(t => t.ParentMenuId == parentMenuId);
            foreach (var chl in children)
            {
                var node = new LeftMenuVm();
                node.id = chl.Id;
                node.title = chl.MenuName??"";
                node.url = chl.MenuUrl??"";
                node.icon =chl.MenuIcon??"";
                node.children = CreateChildTree(allMenuList, node);
                nodeList.Add(node);
            }
            return nodeList;
        }
    }
}