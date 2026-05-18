using Domain.Entities.Models.Horses.Relations;
using Shared.Dtos.OwnershipDtos;
using Shared.Mappers.HorseMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mappers.OwnershipMappers
{
    public static class HorseOwnershipMapper
    {
        public static HorseOwnershipDto ToDto (HorseOwnership ownership)
        {
            return new HorseOwnershipDto
            {
                OwnershipId = ownership.HorseOwnershipId,
                Owner = UserMapper.UserMapper.ToDto(ownership.User),
                Horse = HorseGenerationMapper.horseInfoDto(ownership.Horse)
            };
        }

        public static HorseOwnership ToOwnership (HorseOwnershipDto dto)
        {
            return new HorseOwnership
            {
                HorseOwnershipId = dto.OwnershipId,
                User = UserMapper.UserMapper.ToUser(dto.Owner),
                Horse = HorseGenerationMapper.ToHorse(dto.Horse)
            };
        }
    }
}
