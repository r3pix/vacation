using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using Vacation.Models;

namespace Vacation.Services
{
    public interface IDepartmentService
    {
        Task<int> Create(CreateDepartmentModel model);
        Task Delete(int id);
        Task Update(UpdateDepartmentModel model,int id);
        Task<Pageable<DepartmentModel>> GetAll(GetPageableQuery query);
        Task<DepartmentModel> GetById(int id);
    }
}