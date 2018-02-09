using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeFrame.Models.DbModel;
using CodeFrame.Web.Areas.Manage.Models.Common;

namespace CodeFrame.Web.Models.AutoMapper
{
    public class SelectsModelProfile : Profile
    {
        public SelectsModelProfile()
        {
            CreateMap<RoleInfo, SelectsModel>().ForMember(d => d.value, otp => otp.MapFrom(i => i.Id))
                .ForMember(d => d.text, otp => otp.MapFrom(i => i.RoleName));
            CreateMap<DepartMent, SelectsModel>().ForMember(d => d.value, otp => otp.MapFrom(i => i.Id))
                .ForMember(d => d.text, otp => otp.MapFrom(i => i.DptName));
            CreateMap<Table, SelectsModel>().ForMember(d => d.value, otp => otp.MapFrom(i => i.Id))
                .ForMember(d => d.text, otp => otp.MapFrom(i => i.ShowName));
          
            CreateMap<UserInfo, SelectsModel>().ForMember(d => d.value, otp => otp.MapFrom(i => i.Id));
        }
    }
}
