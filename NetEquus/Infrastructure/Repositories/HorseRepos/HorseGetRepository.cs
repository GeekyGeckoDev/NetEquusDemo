using Application.HorseApp.IHorseRepos;
using Application.HorseApp.UpdateHorse;
using Domain.Entities.Models.Horses;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.HorseDtos;
using Shared.Mappers;
using Shared.Mappers.HorseMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.HorseRepos
{
    public class HorseGetRepository : IHorseGetRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseGetRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<Horse?> GetHorseByIdAsync (Guid horseId)
        {
            return await _context.Horses.Include(h => h.Breed).FirstOrDefaultAsync(h => h.GuidHorseId == horseId);
        }

        public async Task<List<HorseInfoDto>> GetHorsesBySexAsync(int sex)
        {
            var list = await _context.Horses
                .Where(h => h.Sex == (HorseSex)sex)
                .Include(h => h.Breed)
                .ToListAsync();

            return list
                .Select(HorseMapper.horseInfoDto)
                .ToList();
        }

        public async Task<PedigreeDto?> BuildPedigreeAsync(Guid horseId, int generations)
        {

            if (generations <= 0)
                return null;

            var horse = await _context.Horses
                .Include(h => h.Breed)
                .Include(h => h.OffspringRecord)
                    .ThenInclude(f => f.Dam)
                .Include(h => h.OffspringRecord)
                    .ThenInclude(f => f.Sire)
                .FirstOrDefaultAsync(h => h.GuidHorseId == horseId);

            if (horse == null)
                return null;

            return new PedigreeDto
            {
                HorseId = horse.GuidHorseId,
                Height = horse.Height,
                HorseName = horse.HorseName,
                BreedName = horse.Breed.BreedName,
                Age = CalculateHorseAge.CalculateHorseAgeMapper(horse),

                Dam = horse.OffspringRecord?.Dam != null
                    ? await BuildPedigreeAsync(horse.OffspringRecord.Dam.GuidHorseId, generations - 1)
                    : null,

                Sire = horse.OffspringRecord?.Sire != null
                    ? await BuildPedigreeAsync(horse.OffspringRecord.Sire.GuidHorseId, generations - 1)
                    : null
            };
        }
    }
}
