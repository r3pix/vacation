using System.Threading.Tasks;
using PresentSystem.Models;

namespace PresentSystem.Services
{
    public interface IEmploymentTypeService
    {
        Task<int> Create(CreateEmploymentTypeModel model);
    }
}