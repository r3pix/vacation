﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PresenceSystem.Models;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using PresentSystem.Models;

namespace PresentSystem.Services
{
    public interface IEmploymentTypeService
    {
        Task<int> Create(CreateEmploymentTypeModel model);
        Task Delete(int id);
        Task Update(UpdateEmploymentTypeModel model, int id);
        Task<Pageable<EmploymentTypeModel>> GetAll(GetPageableQuery query);
        Task<EmploymentTypeModel> GetById(int id);
    }
}