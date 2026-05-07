using Application.HorseArtistApp.IHorseArtistRepos;
using Application.HorseArtistApp.IHorseArtistServices;
using Domain.DomainRules;
using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.HorseArtistServices
{
    public class HorseArtistValidationService : IHorseArtistValidationService
    {
        private readonly IHorseArtistValidationRepository _hAValidationRepository;

        public HorseArtistValidationService(IHorseArtistValidationRepository haValidationRepository)
        {
            _hAValidationRepository = haValidationRepository;
        }

        public async Task<RuleResult> UserIsAprovedHorseArtist(Guid userId)
        {
            var isApproved = await _hAValidationRepository.UserIsAprovedHorseArtist(userId);

            if (!isApproved)
                return RuleResult.Fail("User is not an approved artist");

            return RuleResult.Success();

        }

        public async Task<RuleResult> UserIsHorseArtist(Guid userId)
        {
            var horseArtistId = await _hAValidationRepository.UserIsHorseArtist(userId);

            if (userId == horseArtistId.HorseArtistId)
                return RuleResult.Fail("User is already a horse artist");

            return RuleResult.Success();

        }
    }
}
