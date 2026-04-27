using Domain.Entities.Models.Users;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mappers.UserMapper
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                UserId = user.User_Id,
                Username = user.Username,
                Email = user.User_Email,
                Password = null,
                IsAdmin = user.IsAdmin
            };
        }

        public static User ToUser(UserDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                User_Email = userDto.Email,
                IsAdmin = userDto.IsAdmin

            };
        }

        public static User ToNewUser(UserRegistrationDto userRegistrationDto)
        {
            return new User
            {
                Username = userRegistrationDto.Username,
                User_Email = userRegistrationDto.Email

            };
        }
    }
}
