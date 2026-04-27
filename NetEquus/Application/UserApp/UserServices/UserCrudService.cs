using Application.UserApp.IUserRepo;
using Application.UserApp.IUserServices;
using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.UserServices
{
    public class UserCrudService : IUserCrudService
    {
        protected readonly IUserCrudRepository _userCrudRepository;

        public UserCrudService(IUserCrudRepository userCrudRepository)
        {
            _userCrudRepository = userCrudRepository;
        }

        public async Task<Guid> CreateUserAsync(User user)
        {
            return await _userCrudRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync (User user)
        {
            await _userCrudRepository.UpdateUserAsync (user);
        }

        public async Task DeleteUserAsync(User user)
        {
            await _userCrudRepository.DeleteUserAsync(user);
        }

    }
}
