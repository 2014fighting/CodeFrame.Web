using System;
using System.Collections.Generic;
using System.Text;
using CodeFrame.Models.DbModel;
using CodeFrame.Models.VModel;

namespace CodeFrame.Service.ServiceInterface
{
    public interface IUserInfoService
    {
        bool AddUserInfo();
        bool LoginVaildate();
        //AuthenticationScheme
        LoginUser GetUserInfo(string userName,string password);
    }
}
