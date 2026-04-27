using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.IUserRepo
{
    public interface IUserCrudRepository
    {
        Task<Guid> CreateUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(User user);
    }
}
