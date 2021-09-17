using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PresenceSystem.Models;
using Vacation.Entities;
using Vacation.Exceptions;
using Vacation.Models;

namespace Vacation.Services
{
    public class UserService : IUserService
    {
        private readonly PresenceSystemDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(PresenceSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<int> Create(CreateUserModel model)
        {
            //weryfikacja czy identity istnieje jest klasa od tego identity z zapytaniami
            var user = _mapper.Map<User>(model);
            user.DateCreated = DateTime.Now;
            user.DateModified = DateTime.Now;
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task Delete(int id)
        {
            //sprawdzenie usera w identity(moze email?)
            var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Id == id);
            if (user is null)
            {
                throw new NotFoundException("Not found");
            }
            //usuniecie identity
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<UserTableModel>> GetAll()
        {
            var results = await _dbContext.Users.Include(x=>x.Department)
                .Include(x=>x.EmploymentType).Include(x=>x.JobTitle)
                .ToListAsync();

            var mappedResults = _mapper.Map<List<UserTableModel>>(results);

            return mappedResults;
        }

        public async Task Update(UpdateUserModel model, int id)
        {
            //sprawdz czy istnieje identity
            //ustaw date edycji i id zmieniajacego
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
            {
                throw new NotFoundException("Not found");
            }

            user.DateModified=DateTime.Now;
           // user.ModifiedById = "identityIDFAF?"
           user.DepartmentId = model.DepartmentId;
           user.DisplayName = model.DisplayName;
           user.JobTitleId = model.JobTitleId;

           _dbContext.Users.Update(user);
           await _dbContext.SaveChangesAsync();
        }
    }
}
