using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CodeFrame.Common.Definitions;

namespace CodeFrame.Common.Definitions
{
    public  class UserSession
    {
        public int? UserId { get; }

        public string UserName { get; }


        public string TrueName { get; }
        public List<int> RoleList { get; }=new List<int>();

        public UserSession()
        { }

        public UserSession(ClaimsPrincipal user)
        {
            // UserId
            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == MyClaimTypes.UserId);
            if (string.IsNullOrEmpty(userIdClaim?.Value))
                return;
            if (int.TryParse(userIdClaim.Value, out int userId))
                UserId = userId;

            // TrueName
            var trueNameClaim = user.Claims.FirstOrDefault(c => c.Type == MyClaimTypes.TrueName);
            TrueName = trueNameClaim?.Value;

            // UsreName
            var userNameClaim = user.Claims.FirstOrDefault(c => c.Type == MyClaimTypes.UserName);
            UserName = userNameClaim?.Value;

            //角色编号可能是多个角色
            user.Claims.Where(c => c.Type == MyClaimTypes.Role).ToList().ForEach(i =>
            {
                RoleList.Add(i.Value.ToInt());
            });
        }
    }
}
