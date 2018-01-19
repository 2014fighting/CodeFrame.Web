using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.Web.Areas.Manage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFrame.Web.Controllers.Api
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[Action]")]
    [EnableCors("any")]
    public class UserApiController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
         
        public UserApiController(IUnitOfWork unitOfWork) 
            => _unitOfWork = unitOfWork;

        [HttpGet]
        public  IActionResult GetTop(int count=3)
        {
            var userModel =  _unitOfWork.GetRepository<UserInfo>().GetPagedList(pageSize: count);

             return Json(new
            {
                code = 0,
                msg = "ok",
                count = userModel.TotalCount,
                data = userModel.Items
               });
        }

        [HttpGet]
        public IActionResult GetUser(int count =1)
        {
            var userModel = _unitOfWork.GetRepository<UserInfo>().GetPagedList(pageSize: count);
            return Ok(userModel);
            
        }


        [HttpGet]
        public ActionResult GetUserInfo(UserInfoModel user, int page = 1, int limit = 10)
        {
            //var w = _unitOfWork.GetRepository<UserInfo>().GetPagedList(pageIndex:page-1,pageSize:limit);

            var result = _unitOfWork.GetRepository<UserInfo>().GetEntities();
            if (!string.IsNullOrEmpty(user.UserName))
                result = result.Where(i => i.UserName.Contains(user.UserName));
            if (!string.IsNullOrEmpty(user.PhoneNo))
                result = result.Where(i => i.PhoneNo.Contains(user.PhoneNo));
            if (!string.IsNullOrEmpty(user.TrueName))
                result = result.Where(i => i.TrueName.Contains(user.TrueName));
            var w1 = result.OrderByDescending(x => x.Id).Skip((page - 1) * limit).Take(limit);
            return Json(new
            {
                code = 0,
                msg = "ok",
                count = result.Count(),
                data = w1.ToList()
            });

        }
    }
}