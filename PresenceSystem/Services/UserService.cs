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

namespace Vacation.Services
{
    public class UserService : IUserService
    {
        private readonly PresenceSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public string[] allowedColumnNames = new[]
        {
            nameof(User.Id),nameof(User.CreatedById),nameof(User.DateCreated),
            nameof(User.DateModified),nameof(User.DisplayName),nameof(User.Email),nameof(User.ModifiedById),
            nameof(User.JobTitle.JobTitleName),nameof(User.Department.DepartmentName),nameof(User.EmploymentType.EmploymentTypeName)
        };
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

        public async Task<Pageable<UserTableModel>> GetAll(GetPageableQuery query)
        {
            var baseQuery = _dbContext.Users.Include(x => x.Department)
                .Include(x => x.EmploymentType).Include(x => x.JobTitle)
                .Where(r=> query.SearchTerm==null ||(r.DisplayName.ToLower().Contains(query.SearchTerm.ToLower())) ||
                           (r.Email.ToLower().Contains(query.SearchTerm.ToLower())) || (r.Department.DepartmentName.ToLower().Contains(query.SearchTerm.ToLower())) ||
                           (r.JobTitle.JobTitleName.ToLower().Contains(query.SearchTerm.ToLower())) || (r.EmploymentType.EmploymentTypeName.ToLower().Contains(query.SearchTerm.ToLower())));


            if (!string.IsNullOrEmpty(query.OrderBy))
            {

                if (allowedColumnNames.Contains(query.OrderBy))
                {
                    var columnsSelector = new Dictionary<string, Expression<Func<User, object>>>()
                    {
                        {nameof(User.CreatedById), r => r.CreatedById},
                        {nameof(User.DateCreated), r => r.DateCreated},
                        {nameof(User.DateModified), r => r.DateModified},
                        {nameof(User.Department.DepartmentName), r => r.Department.DepartmentName},
                        {nameof(User.DisplayName), r => r.DisplayName},
                        {nameof(User.Email), r => r.Email},
                        {nameof(User.EmploymentType.EmploymentTypeName), r => r.EmploymentType.EmploymentTypeName},
                        {nameof(User.JobTitle.JobTitleName), r => r.JobTitle.JobTitleName},
                        {nameof(User.ModifiedById), r => r.ModifiedById},
                        {nameof(User.Id), r => r.Id}

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

            var users = await baseQuery
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();


            
            var result = _mapper.Map<List<UserTableModel>>(users);

            var pagedResult = new Pageable<UserTableModel>();
            pagedResult.Result = result;
            pagedResult.Total = total;
            return pagedResult;
        }

        public async Task<UserTableModel> GetById(int id)
        {
            var result = await _dbContext.Users.Include(x => x.Department)
                .Include(x => x.EmploymentType).Include(x => x.JobTitle)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (result is null)
            {
                throw new NotFoundException("User with provided credentials could not be found");
            }
            var mappedResult = _mapper.Map<UserTableModel>(result);
            return mappedResult;
        }

        public async Task Update(UpdateUserModel model, int id)
        {
            //sprawdz czy istnieje identity
            //ustaw date edycji i id zmieniajacego
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
            {
                throw new NotFoundException("User with provided credentials could not be found");
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
