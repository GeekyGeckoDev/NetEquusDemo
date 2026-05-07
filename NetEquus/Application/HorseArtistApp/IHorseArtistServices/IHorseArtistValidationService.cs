using Domain.DomainRules;
using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.IHorseArtistServices
{
    public interface IHorseArtistValidationService
    {
        Task<RuleResult> UserIsAprovedHorseArtist(Guid userId);

        Task<RuleResult> UserIsHorseArtist(Guid userId);
    }
}
