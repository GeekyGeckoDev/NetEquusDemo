using Application.EstateApp.EstateDtos;
using Shared.Dtos.HorseDtos;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.FolaingDtos
{
    public class FoalingDto
    {
        public Guid FoalingId { get; set; }

        public DateOnly DueDate { get; set; }

        public EstateInfoDto Estate { get; set; }

        public UserDto Breeder { get; set; }

        public HorseInfoDto Foal {  get; set; }

        public HorseInfoDto Sire {  get; set; }

        public HorseInfoDto Dam { get; set; }
    }

    public class CreateFoalingDto
    {
        public Guid MareId { get; set; }

        public Guid StallionId { get; set; }
    }
}
