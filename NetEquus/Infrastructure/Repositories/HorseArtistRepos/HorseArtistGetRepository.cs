using Application.HorseArtistApp.IHorseArtistRepos;
using Domain.Entities.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.HorseArtistRepos
{
    public class HorseArtistGetRepository : IHorseArtistGetRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseArtistGetRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<List<HorseArtist>> GetArtistsByApprovalStatusAsync(bool isApproved)
        {
            return await _context.HorseArtists
                .Include(a => a.User)
                .Where(a => a.IsApproved == isApproved)
                .ToListAsync();
        }

        public async Task<HorseArtist> GetHorseArtistNyUserIdAsync(Guid artistId)
        {
            return await _context.HorseArtists.FindAsync(artistId);
        }
    }
}
