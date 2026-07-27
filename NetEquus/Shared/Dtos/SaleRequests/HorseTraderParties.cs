using Application.EstateApp.EstateDtos;
using Shared.Dtos.HorseDtos;
using Shared.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.SaleRequests
{
    public class HorseTraderSeller
    {
        public EstateDto Estate { get; set; }

        public UserDto User { get; set; }
    }

    public class HorseTraderBuyer
    {

        public EstateDto Estate { get; set; }

        public UserDto User { get; set; }
    }
}
