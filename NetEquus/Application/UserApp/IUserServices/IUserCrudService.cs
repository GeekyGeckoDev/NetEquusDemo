using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.IUserServices
{
    public interface IUserCrudService
    {
        Task<Guid> CreateUserAsync(User user);

        Task DeleteUserAsync(User user);

        Task UpdateUserAsync (User user);
    }
}
