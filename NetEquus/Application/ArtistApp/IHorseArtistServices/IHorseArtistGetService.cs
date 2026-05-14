using Domain.Entities.Models.Users;
using Shared.Dtos.HorseArtistDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.IHorseArtistServices
{
    public interface IHorseArtistGetService
    {
        Task<List<HorseArtistDto>> GetPendingArtistsAsync();

        Task<HorseArtist?> GetHorseArtistByUserIdAsync(Guid artistId);
    }
}
