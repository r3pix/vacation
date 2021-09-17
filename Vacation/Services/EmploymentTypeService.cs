using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PresentSystem.Models;
using Vacation.Entities;

namespace PresentSystem.Services
{
    public class EmploymentTypeService : IEmploymentTypeService
    {
        private readonly PresenceSystemDbContext _dbContext;

        public EmploymentTypeService(PresenceSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(CreateEmploymentTypeModel model)
        {
            var type = new EmploymentType();
            type.Type = model.Type;

            _dbContext.EmploymentTypes.Add(type);
            await _dbContext.SaveChangesAsync();

            return type.Id;
        }

    }
}
