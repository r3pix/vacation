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
    public class PlaceService : IPlaceService
    {
        private readonly PresenceSystemDbContext _dbContext;
        private readonly IMapper _mapper;

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

        public async Task<IEnumerable<PlaceModel>> GetAll()
        {
            var places = await _dbContext.Places.ToListAsync();

            var mappedResults = _mapper.Map<List<PlaceModel>>(places);

            return mappedResults;
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
