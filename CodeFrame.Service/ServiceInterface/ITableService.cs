using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFrame.Service.ServiceInterface
{
    public interface ITableService
    {
        string GetAllMenuAndButtonByRoleId(int roleId);
    }
}
