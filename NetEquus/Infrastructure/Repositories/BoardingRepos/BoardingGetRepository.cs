using Application.BoardingApp.IBoardingRepos;
using Domain.Entities.Models.Horses.Relations;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.BoardingDtos;
using Shared.Mappers.BoardingMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.BoardingRepos
{
    public class BoardingGetRepository : IBoardingGetRepository
    {
        private readonly NetEquusDbContext _context;

        public BoardingGetRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<List<BoardingDto>> GetBoardingsByEstateId(Guid estateId)
        {
            var list = await _context.HorseBoardings
                .Include(b => b.BoardingEstate)
                .Include(b => b.Horse)
                    .ThenInclude(h => h.Breed)
                .Where(b => b.BoardingEstateId == estateId)
                .ToListAsync();

            return list
                .Select(BoardingMapper.ToDto)
                .ToList();
        }

        public async Task<HorseBoarding?> GetBoardingByHorseId(Guid horseId)
        {
            return await _context.HorseBoardings
                .Include(b => b.Horse)
                    .ThenInclude(h => h.Breed)
                .Include(b => b.BoardingEstate)
                .FirstOrDefaultAsync(b => b.HorseGuidId == horseId);
        }




    }
    
}
