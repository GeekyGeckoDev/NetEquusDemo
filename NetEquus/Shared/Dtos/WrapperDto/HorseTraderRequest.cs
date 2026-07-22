using Shared.Dtos.SaleRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.WrapperDto
{
    public class HorseTraderRequest
    {
        public HorseTraderSeller Seller { get; set; }

        public HorseTraderBuyer Buyer { get; set; }

        public decimal Price { get; set; }
    }
}
