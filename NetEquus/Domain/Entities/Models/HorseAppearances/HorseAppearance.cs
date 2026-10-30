using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Models.HorseAppereances
{
    public class HorseAppearance
    {
        [Key]
        public Guid AppearanceId { get; set; }

        public string Image { get; set; }

    }
}
