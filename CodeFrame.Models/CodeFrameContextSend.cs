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
        }


        static IEnumerable<UserInfo> GetPreconfiguredUserInfo()
        {
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
            return rlist;
        }


        static IEnumerable<RoleInfo> GetPreconfiguredRoleInfo()
        {
            return new List<RoleInfo>()
            {
                new RoleInfo() { RoleName="system",CreteTime = DateTime.Now,Describe ="系统角色"}
                ,new RoleInfo() {RoleName="bos",CreteTime = DateTime.Now,Describe ="大bos"}
            };
        }
    }
}
