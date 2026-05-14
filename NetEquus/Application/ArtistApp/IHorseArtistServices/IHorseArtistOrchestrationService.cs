using Domain.DomainRules;
using Domain.Entities.Models.Users;
using Shared.Dtos.HorseArtistDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.IHorseArtistServices
{
    public interface IHorseArtistOrchestrationService
    {
        Task<RuleResult> ValidateAndCreateHorseArtist(Guid userId);

        Task<RuleResult> ApprovePendingArtistAsync(Guid artistId);
    }
}
