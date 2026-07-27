using Domain.Entities.Models.EquineEstates;
using Domain.Entities.Models.Horses;
using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Sales
{

    public class HorseSaleBase
    {
        [Key]
        public Guid HorseSaleId { get; set; }

        [Required, ForeignKey("Horse")]
        public Guid HorseId { get; set; }

        public Horse Horse { get; set; }

        public DateTime DateOfSale { get; set; }

        [Required]
        public Guid SellerUserId { get; set; }

        [ForeignKey(nameof(SellerEstateId))]
        public virtual EquineEstate SellerEstate { get; set; }

        public Guid SellerEstateId { get; set; }

        [ForeignKey(nameof(SellerUserId))]
        public virtual User SellerUser { get; set; }
    }
}
