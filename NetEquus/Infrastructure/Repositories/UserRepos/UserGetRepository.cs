using Application.UserApp.IUserRepos;
using Domain.Entities.Models.Users;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UserRepos
{
    public class UserGetRepository : IUserGetRepository
    {
        private readonly NetEquusDbContext _Dbcontext;

        public UserGetRepository(NetEquusDbContext context)
        {
            _Dbcontext = context;
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _Dbcontext.Users.FindAsync(id);
        }

        public async Task<List<User>> GetUserByNpcStatusAsync(bool isNpc)
        {
            return await _Dbcontext.Users
                .Where(u => u.IsNpc == isNpc)
                .ToListAsync();
        }

        public async Task<User> GetHorseTraderByUserTypeAsync()
        {
            return await _Dbcontext.Users
                .FirstOrDefaultAsync(u => u.UserTypeEnum == UserType.HorseTrader);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _Dbcontext.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetUserByRefreshTokenAsync (string refreshToken)
        {
            return await _Dbcontext.Users
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _Dbcontext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}

