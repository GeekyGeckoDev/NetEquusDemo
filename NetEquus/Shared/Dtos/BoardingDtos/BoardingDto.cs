using Application.EstateApp.EstateDtos;
using Shared.Dtos.HorseDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.BoardingDtos
{
    public class BoardingDto
    {
        public Guid BoardingId { get; set; }
        public HorseInfoDto Horse { get; set; }

        public EstateInfoDto Estate {  get; set; }
    }
}
