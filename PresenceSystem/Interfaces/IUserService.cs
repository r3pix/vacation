using System.Collections.Generic;
using System.Threading.Tasks;
using PresenceSystem.Models;
using Vacation.Models;

namespace Vacation.Services
{
    public interface IUserService
    {
        Task<int> Create(CreateUserModel model);
        Task Delete(int id);
        Task Update(UpdateUserModel model, int id);
        Task<IEnumerable<UserTableModel>> GetAll();
    }
}