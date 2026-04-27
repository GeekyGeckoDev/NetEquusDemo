using Application.SharedApp.OwnershipDtos;
using Domain.Entities.Models.EquineEstates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dtos.UserDtos;

namespace Application.SharedApp.OwnershipMappers
{
    public static class EstateOwnershipMapper
    {
        public static EstateOwnershipDto ToDto(EstateOwnership estateOwnership)
        {
            return new EstateOwnershipDto
            {
                EquineEstateId = estateOwnership.EstateId,
                UserId = estateOwnership.UserId,
                isPrimaryOwner = estateOwnership.IsPrimaryOwner


            };
        }

        public static EstateOwnership ToEstateOwner (EstateOwnershipDto estateOwnershipDto, UserDto userDto)
        {
            return new EstateOwnership
            {
                EstateId = estateOwnershipDto.EquineEstateId,
                UserId = userDto.UserId,
                IsPrimaryOwner = estateOwnershipDto.isPrimaryOwner
            };
        }
    }
}
