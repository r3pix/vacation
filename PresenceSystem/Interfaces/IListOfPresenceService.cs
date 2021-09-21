using System.Collections.Generic;
using System.Threading.Tasks;
using PresenceSystem.Models;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;

namespace PresenceSystem.Services
{
    public interface IListOfPresenceService
    {
        Task<int> Create(CreateListOfPresenceModel model);
        Task Update(UpdateListOfPresenceModel model, int id);
        Task Delete(int id);
        Task<Pageable<ListOfPresenceTableModel>> GetAll(GetPageableQuery query);
        Task<ListOfPresenceTableModel> GetById(int id);
    }
}