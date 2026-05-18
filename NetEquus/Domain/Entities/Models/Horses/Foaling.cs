using Domain.Entities.Models.EquineEstates;
using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Models.Horses
{
    public class Foaling
    {
        [Key]
        public Guid FoalingId   { get; set; }

        public DateTime FoalingDate { get; set; }

        [ForeignKey("EquineEstate")]
        public Guid EquineEstateId { get; set; }

        public virtual EquineEstate FoalingEstate { get; set; }

  
        public Guid BreederId {  get; set; }


        [ForeignKey("User")]
        public virtual User Breeder { get; set; }

        public Guid DamId { get; set; }

        public Guid SireId { get; set; }

        public Guid FoalId { get; set; }




        [ForeignKey("DamId")]
        
        public virtual Horse Dam { get; set; }


        [ForeignKey("FoalId")]
        public virtual Horse Foal { get; set; }

        [ForeignKey("SireId")]
        public virtual Horse Sire { get; set; }
    }
}

