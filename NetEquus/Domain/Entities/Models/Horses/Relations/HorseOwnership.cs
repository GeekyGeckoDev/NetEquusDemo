using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Models.Horses.Relations
{
    public class HorseOwnership
    {
        [Key]
        public Guid HorseOwnershipId { get; set; }

        [ForeignKey("Horse")]
        public Guid HorseGuidId { get; set; }
        public virtual Horse Horse { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }


}
