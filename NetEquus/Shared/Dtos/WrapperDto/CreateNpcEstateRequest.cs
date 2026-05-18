using Application.EstateApp.EstateDtos;
using Shared.Dtos.OwnershipDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.WrapperDto
{
    public class CreateNpcEstateRequest
    {
        public Guid UserId { get; set; }

        public EstateCreationDto Estate { get; set; }

        public EstateOwnershipDto Ownership { get; set; }
    }
}
