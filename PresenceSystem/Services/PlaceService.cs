using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
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
    public class PlaceService : IPlaceService
    {
        private readonly PresenceSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public string[] allowedColumnNames = new[] {nameof(Place.Id),nameof(Place.PlaceName)};
        public PlaceService(PresenceSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(CreatePlaceModel model)
        {
            var place = new Place();
            place.PlaceName = model.PlaceName;
            _dbContext.Places.Add(place);
            await _dbContext.SaveChangesAsync();
            return place.Id;
        }

        public async Task Update(UpdatePlaceModel model,int id)
        {
            var place = await _dbContext.Places.FirstOrDefaultAsync(x => x.Id == id);
            if (place is null)
            {
                throw new NotFoundException("Place with provided credentials");
            }

            place.PlaceName = model.PlaceName;
            _dbContext.Places.Add(place);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Pageable<PlaceModel>> GetAll(GetPageableQuery query)
        {

            var baseQuery = _dbContext.Places.Where(r => query.SearchTerm == null || (r.PlaceName.ToLower().Contains(query.SearchTerm.ToLower())));

            if (!string.IsNullOrEmpty(query.OrderBy))
            {

                if (allowedColumnNames.Contains(query.OrderBy))
                {
                    var columnsSelector = new Dictionary<string, Expression<Func<Place, object>>>()
                    {
                        {nameof(Place.PlaceName), r => r.PlaceName},
                        {nameof(Place.Id), r => r.Id}

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

            var places = await baseQuery
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();


            var total = await _dbContext.Places.CountAsync();
            var result = _mapper.Map<List<PlaceModel>>(places);

            var pagedResult = new Pageable<PlaceModel>();
            pagedResult.Result = result;
            pagedResult.Total = total;
            return pagedResult;
        }

        public async Task<PlaceModel> GetById(int id)
        {
            var place = await _dbContext.Places.FirstOrDefaultAsync(x=>x.Id == id);
            if (place is null)
            {
                throw new NotFoundException("Place with provided credentials could not be found");
            }

            var mappedResult = _mapper.Map<PlaceModel>(place);
            return mappedResult;
        }

        public async Task Delete(int id)
        {
            var place = await _dbContext.Places.FirstOrDefaultAsync(x => x.Id == id);
            if (place is null)
            {
                throw new NotFoundException("Place with provided credentials could not be found");
            }

            _dbContext.Remove(place);
            await _dbContext.SaveChangesAsync();
        }

    }
}
