using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vacation.Entities;
using Vacation.Exceptions;
using Vacation.Models;

namespace Vacation.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly Entities.PresenceSystemDbContext _dbContext;

        public DepartmentService(IMapper mapper, Entities.PresenceSystemDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<int> Create(CreateDepartmentModel model)
        {
            var department = _mapper.Map<Department>(model);
            _dbContext.Departments.Add(department);
            await _dbContext.SaveChangesAsync();
            return department.Id;
        }

        public async Task Delete(int id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department is null)
            {
                throw new NotFoundException("Not found");
            }

            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UpdateDepartmentModel model,int id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(x=>x.Id == id);
            if (department is null)
            {
                throw new NotFoundException("Not found");
            }

            department.DepartmentName = model.DepartmentName;

            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DepartmentModel>> GetAll()
        {
            var departments = await _dbContext.Departments.ToListAsync();

            var result = _mapper.Map<List<DepartmentModel>>(departments);

            return result;
        }

        public async Task<DepartmentModel> GetById(int id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department is null)
            {
                throw new NotFoundException("Not found");
            }
            var result = _mapper.Map<DepartmentModel>(department);

            return result;
        }

    }
}
