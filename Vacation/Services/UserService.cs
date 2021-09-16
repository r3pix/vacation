using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vacation.Entities;
using Vacation.Models;

namespace Vacation.Services
{
    public class UserService : IUserService
    {
        private readonly VacationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(VacationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<int> Create(CreateUserModel model)
        {
            //weryfikacja jest klasa od tego identity z zapytaniami
            var user = _mapper.Map<User>(model);
            user.DateCreated = DateTime.Now;
            user.DateModified = DateTime.Now;
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

    }
}
