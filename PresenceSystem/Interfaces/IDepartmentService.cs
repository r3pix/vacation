using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using PresenceSystem.Querries;
using Vacation.Models;

namespace Vacation.Services
{
    public interface IDepartmentService
    {
        Task<int> Create(CreateDepartmentModel model);
        Task Delete(int id);
        Task Update(UpdateDepartmentModel model,int id);
        Task<Pageable<DepartmentModel>> GetAll(DepartmentQuerry query);
        Task<DepartmentModel> GetById(int id);
    }
}