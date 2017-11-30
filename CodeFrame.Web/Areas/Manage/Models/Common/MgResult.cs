using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFrame.Web.Areas.Manage.Models.Common
{
    public class MgResult
    {
        public MgResult()
        {}
        public MgResult(string msg, int code)
        {
            this.Code = code;
            this.Msg = msg;
        }
        public string Msg { get; set; } = "";
        //默认0为成功，其它均为失败
        public int Code { get; set; } = 0;
    }
}
