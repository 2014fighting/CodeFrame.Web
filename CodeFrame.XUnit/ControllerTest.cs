using System;
using System.Collections.Generic;
using System.Text;
using CodeFrame.Models;
using CodeFrame.Service.Service;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.Web.Controllers;
using Microsoft.EntityFrameworkCore;
using CodeFrame.UnitOfWork;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CodeFrame.XUnit
{
   public  class ControllerTest
    {
        private readonly ILogService _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoService _userInfoService;
        public ControllerTest()
        {
            LogManager.CreateRepository("NETCoreRepository");
            //集成测试
            var optionsBuilder = new DbContextOptionsBuilder<CodeFrameContext>();
            var optionsBuilder1 = optionsBuilder.UseMySql("Server=localhost;database=CodeFrameDb;uid=root;pwd=abc123;");
            _userInfoService = new UserInfoService(
                new UnitOfWork<CodeFrameContext>(new CodeFrameContext(optionsBuilder1.Options)));
            _logger=new LogService();
            _unitOfWork=new UnitOfWork<CodeFrameContext>(new CodeFrameContext(optionsBuilder1.Options));
        }
        [Fact]
        public void ControllerMethod()
        {
            var controller = new AccountController(_userInfoService, _unitOfWork,_logger);

            ActionContext context = new ActionContext();
            var x= controller.GetUserInfo();
             
        }
    }
}
