using Application.EstateApp.EstateDtos;
using Shared.Dtos.OwnershipDtos;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.WrapperDto
{
    public class CreateEstateRequest
    {
        public EstateOwnershipDto Ownership { get; set; }
        public EstateCreationDto Estate { get; set; }
    }
}
