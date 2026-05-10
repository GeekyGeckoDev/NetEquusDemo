using Domain.Entities.Models.Users;
using Shared.Dtos.NpcDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.NpcServices
{
    public class NpcInitilizationService : INpcInitilizationService
    {
        public async Task NpcInitilizationAsync(CreateNpcDto dto)
        {
            var npc = new User
            {
                Username = "System Stable",
                Email = null,
                IsNpc = true,
                CanLogin = false
            };
        }
    }
}
