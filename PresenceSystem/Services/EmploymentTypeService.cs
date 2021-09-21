using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PresenceSystem.Models;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using PresentSystem.Models;
using Vacation.Entities;
using Vacation.Exceptions;
using Vacation.Models;

namespace PresentSystem.Services
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        private readonly PresenceSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public string[] allowedColumnNames = new[] { nameof(EmploymentType.Id),nameof(EmploymentType.Type)};

        public EmploymentTypeService(PresenceSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(CreateEmploymentTypeModel model)
        {
            var type = new EmploymentType();
            type.Type = model.Type;

            _dbContext.EmploymentTypes.Add(type);
            await _dbContext.SaveChangesAsync();

            return type.Id;
        }

        public async Task Delete(int id)
        {
            var type = await _dbContext.EmploymentTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (type is null)
            {
                throw new NotFoundException("Employment type with provided credentials does not exist");
            }

            _dbContext.EmploymentTypes.Remove(type);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UpdateEmploymentTypeModel model, int id)
        {
            var type = await _dbContext.EmploymentTypes.FirstOrDefaultAsync(x=>x.Id == id);
            if (type is null)
            {
                throw new NotFoundException("Employment type with provided credentials does not exist");
            }

            type.Type = model.Type;
            _dbContext.EmploymentTypes.Update(type);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<Pageable<EmploymentTypeModel>> GetAll(GetPageableQuery query)
        {

            var baseQuery = _dbContext.EmploymentTypes.Where(r => query.SearchTerm == null || (r.Type.ToLower().Contains(query.SearchTerm.ToLower())));

            if (!string.IsNullOrEmpty(query.OrderBy))
            {

                if (allowedColumnNames.Contains(query.OrderBy))
                {
                    var columnsSelector = new Dictionary<string, Expression<Func<EmploymentType, object>>>()
                    {
                        {nameof(EmploymentType.Type), r=>r.Type},
                        {nameof(EmploymentType.Id), r => r.Id}

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

            var types = await baseQuery
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            var result = _mapper.Map<List<EmploymentTypeModel>>(types);

            var pagedResult = new Pageable<EmploymentTypeModel>();
            pagedResult.Result = result;
            pagedResult.Total = total;
            return pagedResult;
        }

        public async Task<EmploymentTypeModel> GetById(int id)
        {
            var type = await _dbContext.EmploymentTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (type is null)
            {
                throw new NotFoundException("Employment type with provided credentials does not exist");
            }

            var typeMapped = _mapper.Map<EmploymentTypeModel>(type);

            return typeMapped;
        }
    }
}
