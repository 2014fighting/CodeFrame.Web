using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFrame.Common.Config
{
    public class JwtConfig
    {
        /// <summary>
        /// jwt SecretKey
        /// </summary>
        public static JwtConfigModel JwtConfigModel { get; } =
            ConfigurationManager.GetSection<JwtConfigModel>("JwtSettings");
 
    }

    public class JwtConfigModel
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecretKey { get; set; }

    }

}
