using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Enums;

namespace Domain.Entities.Models.Horses
{
    public class Horse
    {
        [Key]
        public Guid GuidHorseId { get; set; }

        [Required]
        public string HorseName { get; set; }

        public int Age { get; set; }

        public HorseSex Sex { get; set; }

        public int Height { get; set; }

        public DateOnly BirthDate { get; set; }

        public DateOnly AgingDate { get; set; }

        public bool IsFoal { get; set; }

       public Horse(Guid guidHorseId, string horseName, int age, HorseSex sex, int height, DateOnly birthDate, DateOnly agingDate, bool isFoal)
        {
            GuidHorseId = Guid.NewGuid();
            HorseName = horseName;
            Age = age;
            Sex = sex;
            Height = height;
            BirthDate = birthDate;
            AgingDate = agingDate;
            IsFoal = isFoal;
        }
    }
}
