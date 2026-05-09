using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.HorseArtistDtos
{
    public class HorseArtistDto
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public bool IsApproved { get; set; }
    }
}
