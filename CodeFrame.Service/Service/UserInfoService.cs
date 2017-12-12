using System;
using System.Collections.Generic;
using System.Linq;
using CodeFrame.Models.DbModel;
using CodeFrame.Models.VModel;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using Microsoft.EntityFrameworkCore;

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
                Password = "123456666",
                TrueName = "wenqing666"
            });
            return _unitOfWork.SaveChanges() > 0;//提交到数据库

        }

        public UserInfo GetUserInfo(string userName, string password)
        {
            //var user1 = _unitOfWork.GetRepository<UserInfo>()
            //    .GetPagedList(predicate:i => i.Password == password && i.UserName == userName, 
            //                   include: i => i.Include(ur => ur.UserRoles).ThenInclude(r => r.RoleInfo)).Items;


            var user= _unitOfWork.GetRepository<UserInfo>()
                .GetFirstOrDefault(i => i.Password == password
                && i.UserName == userName,include:i=>i.Include(ur=>ur.UserRoles)
                .ThenInclude(r=>r.RoleInfo));
            return user;
        }

        public bool LoginVaildate()
        {
            return true;
        }

        #region 初始化数据库数据
        /// <summary>
        /// 初始化数据库数据
        /// </summary>
        public void InitDbData()
        {
            var repoUser = _unitOfWork.GetRepository<UserInfo>();
            var repoRole = _unitOfWork.GetRepository<RoleInfo>();
            if (!repoUser.GetEntities().Any())
            {
                repoUser.Insert(new List<UserInfo>()
                {
                    new UserInfo() { Id =1, Password = "123456", UserName = "wenqing",
                        PhoneNo = "15659284668", TrueName = "wenqing"}

                });
                for (int i = 1; i < 30; i++)
                {
                    repoUser.Insert(new List<UserInfo>()
                    {
                        new UserInfo() { Id = i+1, Password = "123456", UserName = "超级玛丽"+i,
                            PhoneNo = "15659284668", TrueName = "超级玛丽"+i }

                    });
                }


                repoRole.Insert(new List<RoleInfo>()
                {
                    new RoleInfo() { Id = 1,RoleName="system",CreteTime = DateTime.Now,Describe ="haha"}
                    ,new RoleInfo() { Id = 2,  RoleName="bos",CreteTime = DateTime.Now,Describe ="lihai"}

                });
                _unitOfWork.SaveChanges();
            }

        }
        #endregion
    }
}
