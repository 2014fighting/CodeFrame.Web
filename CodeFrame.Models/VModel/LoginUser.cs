using CodeFrame.Models.DbModel;

namespace CodeFrame.Models.VModel
{
    public class LoginUser:UserInfo
    {
        public string AuthenticationType { get; set; } = "Cookies";
    }
}
