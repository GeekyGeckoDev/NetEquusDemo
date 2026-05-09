using Application.HorseArtistApp.IHorseArtistServices;
using Domain.Entities.Models.Users;
using Shared.Dtos.HorseArtistDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.HorseArtistServices
{
    public class HorseArtistInitializationService : IHorseArtistInitializationService
    {
        private readonly IHorseArtistCrudService _hACrudService;
        private readonly IHorseArtistGetService _hAGetService;

        public HorseArtistInitializationService(IHorseArtistCrudService hACrudService, IHorseArtistGetService hAGetService)
        {
            _hACrudService = hACrudService;
            _hAGetService = hAGetService;
        }

        public async Task LinkUserAndHorseArtistAsync(Guid userId)
        {
            var artist = new HorseArtist
            {
                UserId = userId,
                IsApproved = false
            };

            await _hACrudService.CreateHorseArtistAsync(artist);
        }

        public async Task ApprovePendingArtist(Guid artistId)
        {
            var artist = await _hAGetService.GetHorseArtistByUserIdAsync(artistId);


            if (artist == null)
                throw new Exception("Artist not found.");

            artist.IsApproved = true;

        }
    }
}
