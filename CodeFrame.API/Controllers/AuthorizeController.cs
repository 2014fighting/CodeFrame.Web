using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CodeFrame.Common.Config;
using CodeFrame.Service.ServiceInterface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CodeFrame.API.Model;

namespace CodeFrame.API.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// 基于jwt的授权策略 http://video.jessetalk.cn/course/4/learn#lesson/35
    /// </summary>
    [EnableCors("any")]
    [Produces("application/json")]
    [Route("api/[controller]/[Action]")]
    public class AuthorizeController : Controller
    {
        private readonly IUserInfoService _userInfoService;
        public AuthorizeController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public ActionResult GetToken(LoginViewModel viewModel)
        {
            viewModel.UserName = "wenqing";
            viewModel.Password = "123456";
            var user = _userInfoService.GetUserInfo(viewModel.UserName, viewModel.Password);
            if (user==null)
                return BadRequest();

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

       
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.JwtConfigModel.SecretKey));
            var creds= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token=
                new JwtSecurityToken
                (JwtConfig.JwtConfigModel.Issuer,
                JwtConfig.JwtConfigModel.Audience,
                claims,DateTime.Now,DateTime.Now.AddMinutes(30)
                , creds);
            return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(token)});
        }
    }
}