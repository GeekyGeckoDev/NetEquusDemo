using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Models.Breeds
{
    public class Breed
    {
        [Key]
        public Guid BreedID { get; set; }

        [Required]
        public string BreedName { get; set; }

        [Required]
        public string BreedAbbreviation { get; set; }

        public int MinHeight { get; set; }

        public int MaxHeight { get; set; }
    }
}
