﻿using System;
using System.Collections.Generic;
using System.Text;
using CodeFrame.Models.DbModel;

namespace CodeFrame.Service.ServiceInterface
{
    public interface IUserInfoService
    {
        bool AddUserInfo();
        bool LoginVaildate();
        //AuthenticationScheme
        UserInfo GetUserInfo(string userName,string password);

        void InitDbData();
    }
}
