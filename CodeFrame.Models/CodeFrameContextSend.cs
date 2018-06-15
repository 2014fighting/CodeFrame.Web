using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFrame.Models.DbModel;

namespace CodeFrame.Models
{
    public class CodeFrameContextSend
    {
        public static async Task SeedAsync(CodeFrameContext codeframeContext)
        {
            if (!codeframeContext.UserInfo.Any())
            {
                codeframeContext.UserInfo.AddRange(GetPreconfiguredUserInfo());

                await codeframeContext.SaveChangesAsync();
            }
            if (!codeframeContext.RoleInfo.Any())
            {
                codeframeContext.RoleInfo.AddRange(GetPreconfiguredRoleInfo());

                await codeframeContext.SaveChangesAsync();
            }
            if (!codeframeContext.DepartMent.Any())
            {
                codeframeContext.DepartMent.AddRange(GetPreconfiguredDepartment());

                await codeframeContext.SaveChangesAsync();
            }

        }


        static IEnumerable<UserInfo> GetPreconfiguredUserInfo()
        {
            var rlist = new List<UserInfo>()
            {
                new UserInfo() {Password = "123456", UserName = "wenqing",
                    PhoneNo = "15659284668", TrueName = "文清",Group="1",Picture ="http://siyouku.cn/Content/CommonImg/20140621193541.png"},
                new UserInfo() {Password = "123456", UserName = "admin",
                    PhoneNo = "15659284668", TrueName = "管理员",Group="1",Picture ="http://siyouku.cn/Content/CommonImg/20140621193541.png"},
                new UserInfo() {Password = "123456", UserName = "supadmin",
                    PhoneNo = "15659284668", TrueName = "超级管理员",Group="1",Picture = "http://siyouku.cn/Content/CommonImg/20140621193541.png"}
            };
            for (int i = 1; i < 10; i++)
            {
                rlist.Add(
                    new UserInfo()
                    {
                       
                        Password = "123456",
                        UserName = "LeBronJames" + i,
                        PhoneNo = "15659286666",
                        TrueName = "用户" + i,
                        Group = "2",
                        Picture = "http://siyouku.cn/Content/CommonImg/20140621193541.png"
                    });
            }
            return rlist;
        }


        static IEnumerable<RoleInfo> GetPreconfiguredRoleInfo()
        {
            return new List<RoleInfo>()
            {
                new RoleInfo() { RoleName="经理",CreateTime = DateTime.Now,Describe ="部门经理"},
                new RoleInfo() { RoleName="业务员",CreateTime = DateTime.Now,Describe ="业务员"},
                new RoleInfo() { RoleName="组长",CreateTime = DateTime.Now,Describe ="组长"},
                new RoleInfo() { RoleName="组员",CreateTime = DateTime.Now,Describe ="组员"},
                new RoleInfo() { RoleName="系统管理员",CreateTime = DateTime.Now,Describe ="系统管理员"}
                ,new RoleInfo() {RoleName="超级管理员",CreateTime = DateTime.Now,Describe ="超级管理员"}
            };
        }

        static IEnumerable<DepartMent> GetPreconfiguredDepartment()
        {
            return new List<DepartMent>()
            {
                new DepartMent() { DptName= "技术部",CreateTime = DateTime.Now,IsActive =true,CreateUser = "wenqing",ParentId =0},
                new DepartMent() { DptName= "销售部",CreateTime = DateTime.Now,IsActive =true,CreateUser ="wenqing",ParentId =0},
                new DepartMent() { DptName= "设计部",CreateTime = DateTime.Now,IsActive =true,CreateUser ="wenqing",ParentId =0},
                new DepartMent() { DptName= "技术部",CreateTime = DateTime.Now,IsActive =true,CreateUser ="wenqing",ParentId =0},
                new DepartMent() { DptName= "业务部",CreateTime = DateTime.Now,IsActive =true,CreateUser ="wenqing",ParentId =0}
            };
        }
    }
}
