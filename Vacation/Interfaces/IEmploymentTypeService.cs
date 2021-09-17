using System.Collections.Generic;
using System.Threading.Tasks;
using PresenceSystem.Models;
using PresentSystem.Models;

namespace PresentSystem.Services
{
    public interface IEmploymentTypeService
    {
        Task<int> Create(CreateEmploymentTypeModel model);
        Task Delete(int id);
        Task Update(UpdateEmploymentTypeModel model, int id);
        Task<IEnumerable<EmploymentTypeModel>> GetAll();
        Task<EmploymentTypeModel> GetById(int id);
    }
}