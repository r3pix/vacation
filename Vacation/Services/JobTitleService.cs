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
    public class JobTitleService : IJobTitleService
    {
        private readonly VacationDbContext _dbContext;
        private readonly IMapper _mapper;

        public JobTitleService(VacationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(CreateJobTitleModel model)
        {
            var title = new JobTitle();
            title.TitleName = model.TitleName;

            _dbContext.JobTitles.Add(title);
            await _dbContext.SaveChangesAsync();

            return title.Id;

        }

        public async Task Delete(int id)
        {
            var title = await _dbContext.JobTitles.FirstOrDefaultAsync(x => x.Id == id);
            if (title is null)
            {
                throw new NotFoundException("Not found");
            }

            _dbContext.JobTitles.Remove(title);
            await _dbContext.SaveChangesAsync();

        }

        public async Task Update(UpdateJobTitleModel model, int id)
        {
            var title = await _dbContext.JobTitles.FirstOrDefaultAsync(x => x.Id == id);
            if (title is null)
            {
                throw new NotFoundException("Not found");
            }

            title.TitleName = model.TitleName;
            _dbContext.JobTitles.Update(title);
            await _dbContext.SaveChangesAsync();
        }
        
        
        public async Task<IEnumerable<JobTitleModel>> GetAll()
        {
            var titles = await _dbContext.JobTitles.ToListAsync();
            var result = _mapper.Map<List<JobTitleModel>>(titles);

            return result;
        }

        public async Task<JobTitleModel> GetById(int id)
        {
            var title = await _dbContext.JobTitles.FirstOrDefaultAsync(x => x.Id == id);
            if (title is null)
                throw new NotFoundException("Not found");
            var result = _mapper.Map<JobTitleModel>(title);
            return result;
        }

    }
}
