using Shared.Dtos.HorseArtistDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.IHorseArtistServices
{
    public interface IHorseArtistInitializationService
    {
        Task LinkUserAndHorseArtistAsync(Guid userId);

        Task ApprovePendingArtist(Guid artistId);
    }
}
