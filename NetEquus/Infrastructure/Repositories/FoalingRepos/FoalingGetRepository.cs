
using Application.FoalingApp.IFoalingRepos;
using Domain.Entities.Models.Horses;
using Microsoft.EntityFrameworkCore;
using Shared.GameTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.FoalingRepos
{
    public class FoalingGetRepository : IFoalingGetRepository
    { 
        private readonly NetEquusDbContext _context;
        private readonly IGameTimeService _gameTimeService;
        
        public FoalingGetRepository(NetEquusDbContext context, IGameTimeService gameTimeService)
        {
            _context = context;
            _gameTimeService = gameTimeService;
        }

        public async Task<List<Foaling>> GetDueFoalingsAsync (Guid userId)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var window = _gameTimeService.GetCurrentWindow();

            return await _context.Foalings
                .Where(f =>
                    f.FoalId == null &&
                    (
                        f.DueDate < today ||

                        (f.DueDate == today &&
                         f.BirthTime <= window && f.Status == Domain.Enums.FoalingStatus.InFoal && f.BreederId == userId)
                    ))
                .ToListAsync();
        }
    }
}
