using Domain.DomainRules;
using Shared.Dtos.NpcDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UserApp.NpcServices
{
    public interface INpcManagerService
    {
        Task<RuleResult> CreateNpcUserAsync(CreateNpcDto dto);

        Task<List<NpcDto>> GetNpcsWithoutEstatesAsync();
    }
}
