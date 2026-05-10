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

        public static BreedInfoDto ToDto(Breed breed)
        {
            return new BreedInfoDto
            {
                BreedName = breed.BreedName,
                BreedAbbreviation = breed.BreedAbbreviation,
                MinHeight = breed.MinHeight,
                MaxHeight = breed.MaxHeight
            };

        }

        public static Breed ToBreed(BreedInfoDto dto)
        {
            return new Breed
            {
                BreedID = dto.BreedId,
                BreedName = dto.BreedName,
                BreedAbbreviation = dto.BreedAbbreviation,
                MinHeight = dto.MinHeight,
                MaxHeight = dto.MaxHeight

            };
        }

        public static BreedInfoDto ToInfoDto(Breed breed)
        {
            return new BreedInfoDto
            {
                BreedId = breed.BreedID,
                BreedName = breed.BreedName,
                BreedAbbreviation = breed.BreedAbbreviation,
                MinHeight = breed.MinHeight,
                MaxHeight = breed.MaxHeight
            };

        }

    }
}
