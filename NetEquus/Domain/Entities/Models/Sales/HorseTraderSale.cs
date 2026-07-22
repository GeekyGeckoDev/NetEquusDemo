using Domain.Entities.Models.EquineEstates;
using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Models.Sales
{
    public class HorseTraderSale : HorseSaleBase
    {
        public Guid BuyerUserId { get; set; }

        [ForeignKey(nameof(BuyerUserId))]
        public virtual User BuyerUser {  get; set; }

        public Guid BuyerEstateId { get; set; }

        [ForeignKey(nameof(BuyerEstateId))]
        public virtual EquineEstate BuyerEstate { get; set; }

        public decimal SalesPrice { get; set; }
    }
}
