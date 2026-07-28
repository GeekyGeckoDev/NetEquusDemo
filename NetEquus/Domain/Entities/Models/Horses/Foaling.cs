using Domain.Entities.Models.EquineEstates;
using Domain.Entities.Models.Users;
using Domain.Enums;
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


        [ForeignKey("EquineEstate")]
        public Guid EquineEstateId { get; set; }

        public virtual EquineEstate FoalingEstate { get; set; }

        [ForeignKey("User")]

        public Guid BreederId {  get; set; }

        public DateOnly DueDate { get; set; }

        public DateOnly DateBred {  get; set; }
        
        public virtual User Breeder { get; set; }

        public Guid DamId { get; set; }

        public Guid SireId { get; set; }

        public Guid? FoalId { get; set; }

        public FoalingStatus Status { get; set; }

        public GameWindow BirthTime {  get; set; }


        [ForeignKey("DamId")]
        
        public virtual Horse Dam { get; set; }


        [ForeignKey("FoalId")]
        public virtual Horse Foal { get; set; }

        [ForeignKey("SireId")]
        public virtual Horse Sire { get; set; }

        public Foaling(Guid foalingId, Guid estateId, Guid breederId, Guid damnId, Guid sireId, DateOnly dateBred)
        {
            FoalingId = Guid.NewGuid();
            EquineEstateId = estateId;
            BreederId = breederId;
            DamId = damnId;
            SireId = sireId;
            DateBred = dateBred;

        }

        public Foaling ()
        { }
    }

 
}

