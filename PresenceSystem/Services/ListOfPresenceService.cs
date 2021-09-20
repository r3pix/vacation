using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PresenceSystem.Entities;
using PresenceSystem.Models;
using Vacation.Entities;
using Vacation.Exceptions;

namespace PresenceSystem.Services
{
    public class ListOfPresenceService : IListOfPresenceService
    {
        private readonly PresenceSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public ListOfPresenceService(PresenceSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<int> Create(CreateListOfPresenceModel model)
        {
            var presence = new ListOfPresence();
            presence.PlaceId = model.PlaceId;

            //pobranie emailu z identity, pobranie z bazy id usera z pomoca emaila
            presence.UserId = 2;
            presence.CreatedById = 2;
            presence.ModifiedById = 2;


            presence.Date = DateTime.Today;
            presence.TimeCreated = DateTime.Now;
            presence.TimeModified = DateTime.Now;
            presence.TimeStart = DateTime.Now;
            presence.TimeStop = DateTime.Now.AddHours(8);

            _dbContext.ListOfPresences.Add(presence);
            await _dbContext.SaveChangesAsync();

            return presence.Id;
        }

        public async Task Update(UpdateListOfPresenceModel model, int id)
        {
            var presence = await _dbContext.ListOfPresences.FirstOrDefaultAsync(x => x.Id == id);
            if (presence is null)
            {
                throw new NotFoundException("Presence with provided Id could not be found");
            }

            presence.PlaceId = model.PlaceId;

            //pobranie emailu z identity, pobranie z bazy id usera z pomoca emaila
            presence.ModifiedById = 2;
            presence.TimeModified = DateTime.Now;

            _dbContext.ListOfPresences.Update(presence);

            await _dbContext.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var presence = await _dbContext.ListOfPresences.FirstOrDefaultAsync(x => x.Id == id);
            if (presence is null)
            {
                throw new NotFoundException("Presence with provided Id could not be found");
            }

            _dbContext.ListOfPresences.Remove(presence);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ListOfPresenceTableModel>> GetAll()
        {
            var list = await _dbContext.ListOfPresences
                .Include(x=>x.User)
                .Include(x=>x.Place)
                .ToListAsync();

            var mappedList = _mapper.Map<List<ListOfPresenceTableModel>>(list);

            return mappedList;

        }

        public async Task<ListOfPresenceTableModel> GetById(int id)
        {
            var list = await _dbContext.ListOfPresences
                .Include(x => x.User)
                .Include(x => x.Place)
                .FirstOrDefaultAsync(x => x.Id == id);
            var mappedList = _mapper.Map<ListOfPresenceTableModel>(list);
            return mappedList;
        }

    }
}
