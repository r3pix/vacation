using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PresenceSystem.Models;
using Vacation.Entities;
using Vacation.Models;


namespace Vacation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserModel, User>()
                .ForMember(x => x.Email, m => m.MapFrom(c => c.Email))
                .ForMember(x => x.Department, m => m.MapFrom(c => c.Department))
                .ForMember(x => x.DisplayName, m => m.MapFrom(c => c.DisplayName))
                .ForMember(x => x.EmploymentType, m => m.MapFrom(c => c.EmploymentType))
                .ForMember(x=>x.JobTitle,m=>m.MapFrom(c=>c.JobTitle));


            CreateMap<CreateDepartmentModel, Department>()
                .ForMember(x => x.DepartmentName, m => m.MapFrom(c => c.DepartmentName));

            CreateMap<Department,DepartmentModel>()
                .ForMember(x=>x.DepartmentName,m=>m.MapFrom(c=>c.DepartmentName));

            CreateMap<JobTitle,JobTitleModel>()
                .ForMember(x=>x.TitleName,m=>m.MapFrom(c=>c.TitleName));

            CreateMap<EmploymentType, EmploymentTypeModel>()
                .ForMember(x => x.Type, m => m.MapFrom(c => c.Type));
        }
            
    }
}
