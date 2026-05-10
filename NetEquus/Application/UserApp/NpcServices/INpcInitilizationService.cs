using Shared.Dtos.NpcDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.NpcServices
{
    public interface INpcInitilizationService
    {
        Task NpcInitilizationAsync(CreateNpcDto dto);
    }
}
