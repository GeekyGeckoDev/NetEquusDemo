using Application.HorseArtistApp.IHorseArtistRepos;
using Application.HorseArtistApp.IHorseArtistServices;
using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.HorseArtistServices
{
    public class HorseArtistCrudService : IHorseArtistCrudService
    {
        private readonly IHorseArtistCrudRepository _hACrudRepository;

        public HorseArtistCrudService(IHorseArtistCrudRepository hACrudRepository)
        {
            _hACrudRepository = hACrudRepository;
        }

        public async Task CreateHorseArtistAsync(HorseArtist horseArtist)
        {
            await _hACrudRepository.CreateArtistAsync(horseArtist);
        }
    }
}
