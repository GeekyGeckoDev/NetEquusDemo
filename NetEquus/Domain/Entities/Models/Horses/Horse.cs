using Domain.Entities.Models.Breeds;
using Domain.Entities.Models.Horses.Horsestats;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Models.Horses
{
    public class Horse
    {
        [Key]
        public Guid GuidHorseId { get; set; }

        [Required]
        public string HorseName { get; set; }


        public Guid BreedId { get; set; }


        public virtual Breed Breed { get; set; }

        public HorseSex Sex { get; set; }

        public int Height { get; set; }

        public DateOnly BirthDate { get; set; }

        public DateOnly AgingDate { get; set; }

        public decimal EquinsValue { get; set; }

        public bool IsFoal { get; set; }

        public virtual ICollection<Foaling> FoalingDams { get; set; } = new List<Foaling>();

        public virtual Foaling OffspringRecord { get; set; }

        public DateOnly? CompetitionCoolDown { get; set; }

        public DateOnly? BreedingCoolDown { get; set; }

        public virtual ICollection<Foaling> FoalingSires { get; set; } = new List<Foaling>();

        public virtual ConfPerfTempAttributes ConfPerfTempAttributes { get; set; }

        public Horse(Guid guidHorseId, string horseName, int age, HorseSex sex, int height, DateOnly birthDate, DateOnly agingDate, bool isFoal)
        {
            GuidHorseId = Guid.NewGuid();
            HorseName = horseName;
            Sex = sex;
            Height = height;
            BirthDate = birthDate;
            AgingDate = agingDate;
            IsFoal = isFoal;
        }

        public Horse()
        {

        }
    }
}
