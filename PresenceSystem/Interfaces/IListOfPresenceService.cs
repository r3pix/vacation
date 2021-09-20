using System.Collections.Generic;
using System.Threading.Tasks;
using PresenceSystem.Models;

namespace PresenceSystem.Services
{
    public interface IListOfPresenceService
    {
        Task<int> Create(CreateListOfPresenceModel model);
        Task Update(UpdateListOfPresenceModel model, int id);
        Task Delete(int id);
        Task<IEnumerable<ListOfPresenceTableModel>> GetAll();
        Task<ListOfPresenceTableModel> GetById(int id);
    }
}