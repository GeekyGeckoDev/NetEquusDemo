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
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Password = null,
                IsAdmin = user.IsAdmin
            };
        }

        public static User ToUser(UserDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                IsAdmin = userDto.IsAdmin

            };
        }

        public static User ToNewUser(UserRegistrationDto userRegistrationDto)
        {
            return new User
            {
                Username = userRegistrationDto.Username,
                Email = userRegistrationDto.Email,
                IsAdmin = false


            };
        }
    }
}
