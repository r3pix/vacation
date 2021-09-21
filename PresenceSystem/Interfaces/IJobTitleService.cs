using System.Collections.Generic;
using System.Threading.Tasks;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using Vacation.Models;

namespace Vacation.Services
{
    public interface IJobTitleService
    {
        Task<int> Create(CreateJobTitleModel model);
        Task Delete(int id);
        Task Update(UpdateJobTitleModel model, int id);
        Task<Pageable<JobTitleModel>> GetAll(GetPageableQuery query);
        Task<JobTitleModel> GetById(int id);
    }
}