using Application.HorseArtistApp.IHorseArtistRepos;
using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.HorseArtistRepos
{
    public class HorseArtistCrudRepository : IHorseArtistCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseArtistCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateArtistAsync (HorseArtist horseArtist)
        {
            await _context.HorseArtists.AddAsync (horseArtist);
        }

        public async Task UpdateHorseArtist (HorseArtist horseArtist)
        {
            _context.HorseArtists.Update (horseArtist);
        }

        public async Task DeleteHorseArtist (HorseArtist horseArtist)
        {
            _context.HorseArtists.Remove(horseArtist);
        }

    }
}
