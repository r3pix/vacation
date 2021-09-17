using System.Threading.Tasks;
using Vacation.Models;

namespace Vacation.Services
{
    public interface IUserService
    {
        Task<int> Create(CreateUserModel model);
    }
}