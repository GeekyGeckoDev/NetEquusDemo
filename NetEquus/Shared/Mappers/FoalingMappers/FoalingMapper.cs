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
                DueDate = foaling.DueDate,
                Estate = EstateMapper.ToInfoEstateDto(foaling.FoalingEstate),
                Breeder = UserMapper.UserMapper.ToDto(foaling.Breeder),
                Sire = HorseMapper.horseInfoDto(foaling.Sire),
                Dam = HorseMapper.horseInfoDto(foaling.Dam),
                Foal = HorseMapper.horseInfoDto(foaling.Foal)
            };
        }

        public static Foaling ToFoaling (FoalingDto dto)
        {
            return new Foaling
            {
                FoalingId = dto.FoalingId,
                DueDate = dto.DueDate,
                FoalingEstate = EstateMapper.InfoToEstate(dto.Estate),
                Breeder = UserMapper.UserMapper.ToUser(dto.Breeder),
                Sire = HorseMapper.ToHorse(dto.Sire),
                Dam = HorseMapper.ToHorse(dto.Dam),
                Foal = HorseMapper.ToHorse(dto.Foal)
            };
        }
    }
}
