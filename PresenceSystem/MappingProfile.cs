﻿using System;
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
                .ForMember(x => x.DepartmentId, m => m.MapFrom(c => c.DepartmentId))
                .ForMember(x => x.DisplayName, m => m.MapFrom(c => c.DisplayName))
                .ForMember(x => x.EmploymentTypeId, m => m.MapFrom(c => c.EmploymentTypeId))
                .ForMember(x=>x.JobTitleId,m=>m.MapFrom(c=>c.JobTitleId));


            CreateMap<CreateDepartmentModel, Department>()
                .ForMember(x => x.DepartmentName, m => m.MapFrom(c => c.DepartmentName));

            CreateMap<Department,DepartmentModel>()
                .ForMember(x=>x.DepartmentName,m=>m.MapFrom(c=>c.DepartmentName));

            CreateMap<JobTitle,JobTitleModel>()
                .ForMember(x=>x.TitleName,m=>m.MapFrom(c=>c.TitleName));

            CreateMap<EmploymentType, EmploymentTypeModel>()
                .ForMember(x => x.Type, m => m.MapFrom(c => c.Type));

            CreateMap<User, UserTableModel>()
                .ForMember(x => x.CreatedById, m => m.MapFrom(c => c.CreatedById))
                .ForMember(x => x.DateCreated, m => m.MapFrom(c => c.DateCreated))
                .ForMember(x => x.DateModified, m => m.MapFrom(c => c.DateModified))
                .ForMember(x => x.Department, m => m.MapFrom(c => c.Department.DepartmentName))
                .ForMember(x => x.DisplayName, m => m.MapFrom(c => c.DisplayName))
                .ForMember(x => x.Email, m => m.MapFrom(c => c.Email))
                .ForMember(x => x.EmploymentType, m => m.MapFrom(c => c.EmploymentType.Type))
                .ForMember(x => x.JobTitle, m => m.MapFrom(c => c.JobTitle.TitleName))
                .ForMember(x=>x.ModifiedById,m=>m.MapFrom(c=>c.ModifiedById));
        }
            
    }
}
