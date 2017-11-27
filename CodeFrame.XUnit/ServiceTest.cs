using System;
using System.Collections.Generic;
using System.Text;
using CodeFrame.Models;
using CodeFrame.Service.Service;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CodeFrame.XUnit
{
    public  class ServiceTest
    {
        private readonly IUserInfoService _userInfoService;
        public ServiceTest()
        {
            //集成测试
            var optionsBuilder = new DbContextOptionsBuilder<CodeFrameContext>();
            var optionsBuilder1 = optionsBuilder.UseMySql("Server=localhost;database=CodeFrameDb;uid=root;pwd=abc123;");
            _userInfoService = new UserInfoService(
                new UnitOfWork<CodeFrameContext>(new CodeFrameContext(optionsBuilder1.Options)));
        }
        public void TestMethod()
        {
            var x = _userInfoService.GetUserInfo("wenqing", "123456");
        }
     
    }
}
