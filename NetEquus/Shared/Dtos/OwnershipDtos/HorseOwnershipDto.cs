using Shared.Dtos.HorseDtos;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.OwnershipDtos
{
    public class HorseOwnershipDto
    {
        public Guid OwnershipId { get; set; }
        public HorseInfoDto Horse {  get; set; }

        public UserDto Owner { get; set; }
    }
}
