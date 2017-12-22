 
using AutoMapper;
using CodeFrame.Models.DbModel;
using CodeFrame.Web.Areas.Manage.Models.Common;

namespace CodeFrame.Web.Models.AutoMapper
{
    public class RoleProfile: Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleInfo, SelectsModel>().ForMember(d => d.id, otp => otp.MapFrom(i => i.Id))
                .ForMember(d => d.name, otp => otp.MapFrom(i => i.RoleName));
        }
    }
}
