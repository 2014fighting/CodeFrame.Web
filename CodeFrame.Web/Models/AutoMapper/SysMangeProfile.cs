using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeFrame.Models.DbModel;
using CodeFrame.Web.Areas.Manage.Models;

namespace CodeFrame.Web.Models.AutoMapper
{
    public class SysMangeProfile:Profile
    {
        public SysMangeProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Column, ColumnModel>();
            CreateMap<ColumnModel, Column>();
        }
    }
}
