using Application.HorseArtistApp.IHorseArtistRepos;
using Domain.Entities.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.HorseArtistRepos
{
    public class HorseArtistValidationRepository : IHorseArtistValidationRepository
    {
    {
        private readonly NetEquusDbContext _context;

        public HorseArtistValidationRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserIsAprovedHorseArtist(Guid userId)
        {
            return await _context.HorseArtists.AnyAsync(hA => hA.UserId == userId && hA.IsApproved);
        }

        public async Task<HorseArtist?> UserIsHorseArtist(Guid userId)
        {
            return await _context.HorseArtists.FirstOrDefaultAsync(hA => hA.UserId.Equals(userId));

        }
    }
}
