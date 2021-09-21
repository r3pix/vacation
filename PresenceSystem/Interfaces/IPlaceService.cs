using System.Collections.Generic;
using System.Threading.Tasks;
using PresenceSystem.Models;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;

namespace PresenceSystem.Services
{
    public interface IPlaceService
    {
        Task<int> Create(CreatePlaceModel model);
        Task Update(UpdatePlaceModel model,int id);
        Task<Pageable<PlaceModel>> GetAll(GetPageableQuery query);
        Task<PlaceModel> GetById(int id);
        Task Delete(int id);
    }
}