
using Domain.Entities.Models.EquineEstates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dtos.UserDtos;
using Shared.Dtos.OwnershipDtos;

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
                //isPrimaryOwner = estateOwnership.IsPrimaryOwner


            };
        }

        public static EstateOwnership ToEstateOwnership (EstateOwnershipDto estateOwnershipDto, UserDto userDto)
        {
            return new EstateOwnership
            {
                EstateId = (Guid)estateOwnershipDto.EquineEstateId,
                UserId = userDto.UserId,

                //IsPrimaryOwner = estateOwnershipDto.isPrimaryOwner
            };
        }
    }
}
