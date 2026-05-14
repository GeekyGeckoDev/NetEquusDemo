using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.IHorseArtistRepos
{
    public interface IHorseArtistCrudRepository
    {
        Task CreateArtistAsync(HorseArtist horseArtist);

        Task UpdateHorseArtistAsync(HorseArtist horseArtist);

        Task DeleteHorseArtistAsync(HorseArtist horseArtist);
    }
}
