using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos.UserDtos
{
    public class UserDto
    {

        public Guid UserId { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public int UserType { get; set;  }

    }

    public class UserRegistrationDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
