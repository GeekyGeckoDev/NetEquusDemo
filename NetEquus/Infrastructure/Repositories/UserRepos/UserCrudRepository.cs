using Application.UserApp.IUserRepo;
using Domain.Entities.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.UserRepos
{
    public class UserCrudRepository : IUserCrudRepository
    {
        private readonly NetEquusDbContext _dbContext;

        public UserCrudRepository(NetEquusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            return user.UserId;
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
    
        }

        public async Task DeleteUserAsync(User user)
        {
            _dbContext.Users.Remove(user);
 
        }
    }
}
