using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserApp.IUserRepos
{
    public interface IUserGetRepository
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetUserByUsernameAsync(string username);

        Task<User?> GetUserByRefreshTokenAsync(string refreshToken);

        Task<User?> GetUserByEmailAsync(string email);
    }
}
