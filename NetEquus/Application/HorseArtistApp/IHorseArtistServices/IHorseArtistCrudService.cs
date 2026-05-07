using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.IHorseArtistServices
{
    public interface IHorseArtistCrudService
    {
        Task CreateHorseArtistAsync(HorseArtist horseArtist);
    }
}
