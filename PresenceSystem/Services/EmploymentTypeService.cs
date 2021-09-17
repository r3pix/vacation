using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PresenceSystem.Models;
using PresentSystem.Models;
using Vacation.Entities;
using Vacation.Exceptions;

namespace PresentSystem.Services
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        private readonly PresenceSystemDbContext _dbContext;
        private readonly IMapper _mapper;

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

        public async Task<IEnumerable<EmploymentTypeModel>> GetAll()
        {
            var types =await _dbContext.EmploymentTypes.ToListAsync();

            var typesMapped = _mapper.Map<List<EmploymentTypeModel>>(types);

            return typesMapped;
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
