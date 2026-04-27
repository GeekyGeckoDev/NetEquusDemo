using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos
{
    public class UserRefreshTokenRequestDto
    {
        public Guid User_Id { get; set; }
        public required string RefreshToken { get; set; }
    }
}
