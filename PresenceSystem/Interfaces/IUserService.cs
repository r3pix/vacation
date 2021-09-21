using System.Collections.Generic;
using System.Threading.Tasks;
using PresenceSystem.Models;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using Vacation.Entities;
using Vacation.Models;

namespace Vacation.Services
{
    public interface IUserService
    {
        Task<int> Create(CreateUserModel model);
        Task Delete(int id);
        Task Update(UpdateUserModel model, int id);
        Task<Pageable<UserTableModel>> GetAll(GetPageableQuery query);
        Task<UserTableModel> GetById(int id);
    }
}