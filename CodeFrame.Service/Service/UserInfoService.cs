using System;
using System.Collections.Generic;
using System.Linq;
using CodeFrame.Models.DbModel;
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

            var rlist = new List<UserInfo>()
            {
                new UserInfo() {Password = "123456", UserName = "wenqing",
                    PhoneNo = "15659284668", TrueName = "文清"},
                new UserInfo() {Password = "123456", UserName = "admin",
                    PhoneNo = "15659284668", TrueName = "管理员"},
                new UserInfo() {Password = "123456", UserName = "supadmin",
                    PhoneNo = "15659284668", TrueName = "超级管理员"}
            };
            for (int i = 1; i < 30; i++)
            {
                rlist.Add(
                    new UserInfo()
                    {
                        Password = "123456",
                        UserName = "LeBronJames" + i,
                        PhoneNo = "15659286666",
                        TrueName = "勒布朗·詹姆斯" + i
                    });
            }
            if (!repoUser.GetEntities().Any()) { 
                repoUser.Insert(rlist);
                _unitOfWork.SaveChanges(); //提交到数据库
            }
            return true;
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
               
                for (int i =0; i < 30; i++)
                {
                     
                    repoUser.Insert(new List<UserInfo>()
                    {
                        new UserInfo() {  Password = "123456", UserName = "超级玛丽"+i,
                            PhoneNo = "15659284668", TrueName = "超级玛丽"+i }

                    });
                }
 
                _unitOfWork.SaveChanges();
            }

        }
        #endregion
    }
}
