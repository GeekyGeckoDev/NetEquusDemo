using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Shared.Dtos.UserDtos
{
    public class UserMeDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

    }
}
