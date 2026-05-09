using Application.HorseArtistApp.IHorseArtistRepos;
using Application.HorseArtistApp.IHorseArtistServices;
using Domain.Entities.Models.Users;
using Shared.Dtos.HorseArtistDtos;
using Shared.Mappers.HorseArtistMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.HorseArtistServices
{
    public class HorseArtistGetService : IHorseArtistGetService

    {
        private readonly IHorseArtistGetRepository _hAGetrepository;

        public HorseArtistGetService(IHorseArtistGetRepository haGetrepository)
        {
            _hAGetrepository = haGetrepository;
        }

        public async Task<List<HorseArtistDto>> GetPendingArtistsAsync()
        {
            var artists = await _hAGetrepository.GetArtistsByApprovalStatusAsync(false);

            return artists.Select(HorseArtistMapper.ToDto).ToList();
        }

        public async Task<HorseArtist?> GetHorseArtistByUserIdAsync (Guid artistId)
        {
            return await _hAGetrepository.GetHorseArtistNyUserIdAsync(artistId);
        }
    }


}
