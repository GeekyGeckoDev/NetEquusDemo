using Domain.Entities.Models.Users;
using Shared.Dtos.NpcDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mappers.NpcMappers
{
    public static class NpcMapper
    {
        public static User ToNewNpc(CreateNpcDto dto)
        {
            return new User
            {

                Username = dto.Username,
                CanLogin = false,
                IsNpc = true
            };
        }

        public static NpcDto ToNpcDto(User user)
        {
            return new NpcDto
            {
                NpcId = user.UserId,
                Username = user.Username,
                CanLogin = user.CanLogin,
                IsNpc = user.IsNpc,
            };
        }
    }
}
