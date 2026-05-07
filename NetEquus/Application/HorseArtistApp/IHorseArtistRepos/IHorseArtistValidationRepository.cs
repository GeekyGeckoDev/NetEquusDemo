using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.IHorseArtistRepos
{
    public interface IHorseArtistValidationRepository
    {
        Task<bool> UserIsAprovedHorseArtist(Guid userId);

        Task<HorseArtist?> UserIsHorseArtist(Guid userId);
    }
}
