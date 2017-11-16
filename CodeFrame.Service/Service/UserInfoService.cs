using System;
using System.Collections.Generic;
using CodeFrame.Models.DbModel;
using CodeFrame.Models.VModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;

namespace CodeFrame.Service.Service
{
    public class UserInfoService : IUserInfoService
    {
        private readonly  IUnitOfWork _unitOfWork;
        public UserInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddUserInfo()
        {
            var repoUser = _unitOfWork.GetRepository<UserInfo>();
            var repoRole = _unitOfWork.GetRepository<RoleInfo>();
            var repoUr = _unitOfWork.GetRepository<UserRole>();

            //repoUr.Find();

            //repoRole.Insert(new RoleInfo()
            //{
            //    RoleName = "炒鸡管理11",
            //    Describe = "miaoshu11"
            //});
            //_unitOfWork.SaveChanges();
            repoUser.Insert(new UserInfo
            {
                UserName = "wenqing" + new Random().Next(),
                Password = "123456",
                TrueName = "wenqing1",
                UserRoles = new List<UserRole>() { new UserRole()
                {
                   RoleInfo = new RoleInfo()
                    {
                        RoleName ="炒鸡管理",
                        Describe ="miaoshu"
                    }
                }}
            });
            return _unitOfWork.SaveChanges() > 0;//提交到数据库

        }

        public UserInfo GetUserInfo(string userName, string password)
        {
            return  _unitOfWork.GetRepository<UserInfo>()
                .GetFirstOrDefault(predicate:i => i.Password == password && i.UserName == userName);
            
        }

        public bool LoginVaildate()
        {
            return true;
        }
    }
}
