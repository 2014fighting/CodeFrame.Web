using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFrame.Web.Controllers.Api
{
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
            return Ok(userModel);
        }

        [HttpGet]
        public IActionResult GetUser(int count =1)
        {
            var userModel = _unitOfWork.GetRepository<UserInfo>().GetPagedList(pageSize: count);
            return Ok(userModel);
        }
    }
}