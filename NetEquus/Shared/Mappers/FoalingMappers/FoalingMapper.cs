using Domain.Entities.Models.Horses;
using Shared.Dtos.FolaingDtos;
using Shared.Mappers.EstateMappers;
using Shared.Mappers.HorseMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mappers.FoalingMappers
{
    public  class FoalingMapper
    {
        public static FoalingDto ToDto (Foaling foaling)
        {
            return new FoalingDto
            {
                FoalingId = foaling.FoalingId,
                FoalingDate = foaling.FoalingDate,
                Estate = EstateMapper.ToInfoEstateDto(foaling.FoalingEstate),
                Breeder = UserMapper.UserMapper.ToDto(foaling.Breeder),
                Sire = HorseGenerationMapper.horseInfoDto(foaling.Sire),
                Dam = HorseGenerationMapper.horseInfoDto(foaling.Dam),
                Foal = HorseGenerationMapper.horseInfoDto(foaling.Foal)
            };
        }

        public static Foaling ToFoaling (FoalingDto dto)
        {
            return new Foaling
            {
                FoalingId = dto.FoalingId,
                FoalingDate = dto.FoalingDate,
                FoalingEstate = EstateMapper.InfoToEstate(dto.Estate),
                Breeder = UserMapper.UserMapper.ToUser(dto.Breeder),
                Sire = HorseGenerationMapper.ToHorse(dto.Sire),
                Dam = HorseGenerationMapper.ToHorse(dto.Dam),
                Foal = HorseGenerationMapper.ToHorse(dto.Foal)
            };
        }
    }
}
