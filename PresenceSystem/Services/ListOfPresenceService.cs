using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PresenceSystem.Entities;
using PresenceSystem.Models;
using PresenceSystem.Pageable;
using PresenceSystem.Pageable.PresenceSystem.Pageable;
using Vacation.Entities;
using Vacation.Exceptions;
using Vacation.Models;

namespace PresenceSystem.Services
{
    public class ListOfPresenceService : IListOfPresenceService
    {
        private readonly PresenceSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public string[] allowedColumnNames = new[]
        {
            nameof(ListOfPresence.CreatedById),nameof(ListOfPresence.Date),
            nameof(ListOfPresence.Id),nameof(ListOfPresence.Place.PlaceName),
            nameof(ListOfPresence.TimeCreated),nameof(ListOfPresence.TimeModified),nameof(ListOfPresence.TimeStart),
            nameof(ListOfPresence.TimeStop),nameof(ListOfPresence.User.DisplayName),nameof(ListOfPresence.ModifiedById)
        };
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

        public async Task<Pageable<ListOfPresenceTableModel>> GetAll(GetPageableQuery query)
        {
            var baseQuery = _dbContext.ListOfPresences
                .Include(x => x.User)
                .Include(x => x.Place)
                .Where(r=> query.SearchTerm==null ||(r.Place.PlaceName.ToLower().Contains(query.SearchTerm)) || 
                           (r.User.DisplayName.ToLower().Contains(query.SearchTerm)));


            if (!string.IsNullOrEmpty(query.OrderBy))
            {

                if (allowedColumnNames.Contains(query.OrderBy))
                {
                    var columnsSelector = new Dictionary<string, Expression<Func<ListOfPresence, object>>>()
                    {
                        {nameof(ListOfPresence.CreatedById), r => r.CreatedById},
                        {nameof(ListOfPresence.Date), r => r.Date},
                        {nameof(ListOfPresence.TimeCreated), r => r.TimeCreated},
                        {nameof(ListOfPresence.TimeModified), r => r.TimeModified},
                        {nameof(ListOfPresence.TimeStart), r => r.TimeStart},
                        {nameof(ListOfPresence.TimeStop), r => r.TimeStop},
                        {nameof(ListOfPresence.ModifiedById), r => r.ModifiedById},
                        {nameof(ListOfPresence.Place.PlaceName), r => r.Place.PlaceName},
                        {nameof(ListOfPresence.User.DisplayName), r => r.User.DisplayName},
                        {nameof(ListOfPresence.Id), r => r.Id}

                    };

                    var selectedColumn = columnsSelector[query.OrderBy];

                    if (!query.Desc)
                    {
                        baseQuery = baseQuery.OrderBy(selectedColumn);
                    }
                    else
                        baseQuery = baseQuery.OrderByDescending(selectedColumn);
                }
            }

            var total = await baseQuery.CountAsync();

            var presences = await baseQuery
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();


            var result = _mapper.Map<List<ListOfPresenceTableModel>>(presences);

            var pagedResult = new Pageable<ListOfPresenceTableModel>();
            pagedResult.Result = result;
            pagedResult.Total = total;
            return pagedResult;
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
