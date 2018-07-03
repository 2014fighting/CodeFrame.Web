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

            if (!codeframeContext.RoleInfo.Any())
            {
                codeframeContext.RoleInfo.AddRange(GetPreconfiguredRoleInfo());

                await codeframeContext.SaveChangesAsync();
            }


            if (!codeframeContext.UserInfo.Any())
            {
                codeframeContext.UserInfo.AddRange(GetPreconfiguredUserInfo());

                await codeframeContext.SaveChangesAsync();
            }
         
            if (!codeframeContext.DepartMent.Any())
            {
                codeframeContext.DepartMent.AddRange(GetPreconfiguredDepartment());

                await codeframeContext.SaveChangesAsync();
            }
            if (!codeframeContext.SubSystem.Any())
            {
                codeframeContext.SubSystem.AddRange(GetPreconfiguredSubsystem());

                await codeframeContext.SaveChangesAsync();
            }
            if (!codeframeContext.Menu.Any())
            {
                codeframeContext.Menu.AddRange(GetPreconfiguredMenu());

                await codeframeContext.SaveChangesAsync();
            }
            if (!codeframeContext.Button.Any())
            {
                codeframeContext.Button.AddRange(GetPreconfiguredButton());

                await codeframeContext.SaveChangesAsync();
            }
            
        }


        static IEnumerable<UserInfo> GetPreconfiguredUserInfo()
        {
            var rlist = new List<UserInfo>()
            {
                new UserInfo() {Password = "123456", UserName = "wenqing",UserRoles =new List<UserRole>(){new UserRole(){RoleId = 6} },
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


        static IEnumerable<SubSystem> GetPreconfiguredSubsystem()
        {
            return new List<SubSystem>()
            {
                new SubSystem() { SystemName ="系统配置",SystemIcon="&#xe658;",CreateTime = DateTime.Now,IsActive =true,CreateUser = "wenqing"},
                new SubSystem() { SystemName="订单系统",SystemIcon="&#xe62a;", CreateTime = DateTime.Now,IsActive =true,CreateUser ="wenqing"},
                new SubSystem() {  SystemName="物流系统",SystemIcon="&#xe64c;",CreateTime = DateTime.Now,IsActive =true,CreateUser ="wenqing"}
            };
        }

        static IEnumerable<Menu> GetPreconfiguredMenu()
        {
            return new List<Menu>()
            {
                new Menu() { MenuName = "系统管理",MenuIcon= "fa-cubes",SubSystemId =1,CreateTime = DateTime.Now,IsActive =true,CreateUser = "wenqing"},
                new Menu() { MenuName = "用户管理",MenuIcon= "&#xe6c6;",ParentMenuId =1,MenuUrl = "/manage/UserInfo/Index",SubSystemId =1,CreateTime = DateTime.Now,IsActive =true,CreateUser = "wenqing"},
                new Menu() { MenuName = "角色管理",MenuIcon= "&#xe63c;",ParentMenuId =1,MenuUrl = "/manage/RoleInfo/Index",SubSystemId =1,CreateTime = DateTime.Now,IsActive =true,CreateUser = "wenqing"},
                new Menu() { MenuName = "按钮管理",MenuIcon= "&#xe63c;",ParentMenuId =1,MenuUrl = "/manage/Button/Index",SubSystemId =1,CreateTime = DateTime.Now,IsActive =true,CreateUser = "wenqing"},
                new Menu() { MenuName = "菜单管理",MenuIcon= "&#xe656;",ParentMenuId =1,MenuUrl = "/manage/Menu/Index",SubSystemId =1,CreateTime = DateTime.Now,IsActive =true,CreateUser = "wenqing"},

            };
        }


        static IEnumerable<Button> GetPreconfiguredButton()
        {
            return new List<Button>()
            {
                new Button() {MenuId =4,BtnIcon ="&#xe654;",BtnName ="新增",BtnScript ="add",CreateTime =DateTime.Now,CreateUser ="wenqing",EditType =1,IsActive=true,OrderBy = 1,CreateUserId =3,BtnPosition = 1,IsSpecial =true},
                new Button() {MenuId =4,BtnIcon ="&#xe642;",BtnName ="编辑",BtnScript ="edit",CreateTime =DateTime.Now,CreateUser ="wenqing",EditType =1,IsActive=true,OrderBy = 1,CreateUserId =3,BtnPosition = 1,IsSpecial =true},
                new Button() {MenuId =4,BtnIcon ="&#xe640;", BtnName ="删除",BtnScript ="del",CreateTime =DateTime.Now,CreateUser ="wenqing",EditType =1,IsActive=true,OrderBy = 1,CreateUserId =3,BtnPosition = 2,IsSpecial =true},
                new Button() {MenuId =4,BtnIcon ="&#xe640;",BtnName ="查看",BtnScript ="detail",CreateTime =DateTime.Now,CreateUser ="wenqing",EditType =1,IsActive=true,OrderBy = 1,CreateUserId =3,BtnPosition = 2,IsSpecial =true},
                new Button() {MenuId =3,BtnIcon = "&#xe630;",BtnName ="分配权限",BtnScript ="power",CreateTime =DateTime.Now,CreateUser ="wenqing",EditType =0,IsActive=true,OrderBy = 1,CreateUserId =3,BtnPosition =1,IsSpecial =true},

            };
        }
    }
}
