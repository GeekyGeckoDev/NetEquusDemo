using Domain.Entities.Models.EquineEstates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Models.Horses.Relations
{
    public class HorseBoarding
    {
        [Key]
        public Guid HorseBoardingId { get; set; }

        [Required]
        [ForeignKey("Horse")]
        public Guid HorseGuidId { get; set; }

        public virtual Horse Horse {  get; set; }

        [Required]
        [ForeignKey("EquineEstate")]
        public Guid BoardingEstateId { get; set; }

        public virtual EquineEstate BoardingEstate { get; set; }
    }
}
