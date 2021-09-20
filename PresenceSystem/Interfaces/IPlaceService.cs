using System.Collections.Generic;
using System.Threading.Tasks;
using PresenceSystem.Models;

namespace PresenceSystem.Services
{
    public interface IPlaceService
    {
        Task<int> Create(CreatePlaceModel model);
        Task Update(UpdatePlaceModel model,int id);
        Task<IEnumerable<PlaceModel>> GetAll();
        Task<PlaceModel> GetById(int id);
        Task Delete(int id);
    }
}