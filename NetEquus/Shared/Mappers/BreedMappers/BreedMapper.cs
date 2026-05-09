using Domain.Entities.Models.Breeds;
using Shared.Dtos.BreedDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mappers.BreedMappers
{
    public static class BreedMapper
    {
        public static Breed ToEntity (BreedDto dto)
        {
            return new Breed
            {
                BreedName = dto.BreedName,
                BreedAbbreviation = dto.BreedAbbreviation,
                MinHeight = dto.MinHeight,
                MaxHeight = dto.MaxHeight

            };
        }
    }
}
