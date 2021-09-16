using System.Collections.Generic;
using System.Threading.Tasks;
using Vacation.Models;

namespace Vacation.Services
{
    public interface IJobTitleService
    {
        Task<int> Create(CreateJobTitleModel model);
        Task Delete(int id);
        Task Update(UpdateJobTitleModel model, int id);
        Task<IEnumerable<JobTitleModel>> GetAll();
        Task<JobTitleModel> GetById(int id);
    }
}