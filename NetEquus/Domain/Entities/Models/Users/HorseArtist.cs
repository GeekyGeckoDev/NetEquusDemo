using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Models.Users
{
  
        public class HorseArtist
        {
            [Key]
            public Guid HorseArtistId { get; set; }

            public Guid UserId { get; set; }

            public int SubmissionsAwaiting { get; set; }

            public int SubmissionAccepted { get; set; }

            public bool IsApproved { get; set; }


        [ForeignKey("UserId")]
            public virtual User User { get; set; }
        }
    }

