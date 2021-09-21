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
    public class JobTitleService : IJobTitleService
    {
        private readonly Entities.PresenceSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public string[] allowedColumnNames = new[] {nameof(JobTitle.Id),nameof(JobTitle.Id)};


        public JobTitleService(Entities.PresenceSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(CreateJobTitleModel model)
        {
            var title = new JobTitle();
            title.JobTitleName = model.JobTitleName;

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

            title.JobTitleName = model.JobTitleName;
            _dbContext.JobTitles.Update(title);
            await _dbContext.SaveChangesAsync();
        }
        
        
        public async Task<Pageable<JobTitleModel>> GetAll(GetPageableQuery query)
        {
            var baseQuery = _dbContext.JobTitles.Where(r => query.SearchTerm == null || (r.JobTitleName.ToLower().Contains(query.SearchTerm.ToLower())));

            if (!string.IsNullOrEmpty(query.OrderBy))
            {

                if (allowedColumnNames.Contains(query.OrderBy))
                {
                    var columnsSelector = new Dictionary<string, Expression<Func<JobTitle, object>>>()
                    {
                        {nameof(JobTitle.JobTitleName), r => r.JobTitleName},
                        {nameof(JobTitle.Id), r => r.Id}

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

            var titles = await baseQuery
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();


            var result = _mapper.Map<List<JobTitleModel>>(titles);

            var pagedResult = new Pageable<JobTitleModel>();
            pagedResult.Result = result;
            pagedResult.Total = total;
            return pagedResult;
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
