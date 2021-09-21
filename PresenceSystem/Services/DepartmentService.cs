using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using Vacation.Entities;
using Vacation.Exceptions;
using Vacation.Models;

namespace Vacation.Services
{

    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly Entities.PresenceSystemDbContext _dbContext;
        public string[] allowedColumnNames = new[] {nameof(Department.DepartmentName), nameof(Department.Id)};


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
                throw new NotFoundException("Department with provided credentials does not exist");
            }

            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UpdateDepartmentModel model,int id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(x=>x.Id == id);
            if (department is null)
            {
                throw new NotFoundException("Department with provided credentials does not exist");
            }

            department.DepartmentName = model.DepartmentName;

            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Pageable<DepartmentModel>> GetAll(GetPageableQuery query)
        {
            
            var baseQuery = _dbContext.Departments.Where(r=> query.SearchTerm==null || (r.DepartmentName.ToLower().Contains(query.SearchTerm.ToLower())));
            
            if (!string.IsNullOrEmpty(query.OrderBy))
            {

                if(allowedColumnNames.Contains(query.OrderBy))
                {
                    var columnsSelector = new Dictionary<string, Expression<Func<Department, object>>>()
                    {
                        {nameof(Department.DepartmentName), r => r.DepartmentName},
                        {nameof(Department.Id), r => r.Id}

                    };

                    var selectedColumn = columnsSelector[query.OrderBy];

                    if (!query.Desc)
                    {
                        baseQuery = baseQuery.OrderBy(selectedColumn);
                    }
                    else
                        baseQuery = baseQuery.OrderByDescending(selectedColumn);
                }
            }

            var total = await baseQuery.CountAsync();

            var departments = await baseQuery
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
            
            var result = _mapper.Map<List<DepartmentModel>>(departments);

            var pagedResult = new Pageable<DepartmentModel>();
            pagedResult.Result = result;
            pagedResult.Total = total;
            return pagedResult;
        }

        public async Task<DepartmentModel> GetById(int id)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department is null)
            {
                throw new NotFoundException("Department with provided credentials does not exist");
            }
            var result = _mapper.Map<DepartmentModel>(department);

            return result;
        }

    }
}
