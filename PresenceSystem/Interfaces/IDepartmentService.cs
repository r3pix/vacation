﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vacation.Models;

namespace Vacation.Services
{
    public interface IDepartmentService
    {
        Task<int> Create(CreateDepartmentModel model);
        Task Delete(int id);
        Task Update(UpdateDepartmentModel model,int id);
        Task<IEnumerable<DepartmentModel>> GetAll();
        Task<DepartmentModel> GetById(int id);
    }
}