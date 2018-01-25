using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CodeFrame.Common.Definitions
{
    public  class MyClaimTypes
    {
        /// <summary>
        /// 账号
        /// </summary>
        public static string UserName { get; } = ClaimTypes.GivenName;
        /// <summary>
        /// id
        /// </summary>
        public static string UserId { get; } = ClaimTypes.NameIdentifier;

        /// <summary>
        /// 真实姓名
        /// </summary>
        public static string TrueName { get; } = ClaimTypes.Name;
        /// <summary>
        /// 角色
        /// </summary>
        public static string Role { get; } = ClaimTypes.Role;
 
    }
}
