using Domain.Entities.Models.Horses.Relations;
using Shared.Dtos.BoardingDtos;
using Shared.Mappers.EstateMappers;
using Shared.Mappers.HorseMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mappers.BoardingMappers
{
    public class BoardingMapper
    {
        public static BoardingDto ToDto (HorseBoarding horseBoarding)
        {
            return new BoardingDto
            {
                BoardingId = horseBoarding.HorseBoardingId,

                Horse = HorseMapper.horseInfoDto(horseBoarding.Horse),

                Estate = EstateMapper.ToInfoEstateDto(horseBoarding.BoardingEstate)
            };
        }

        public static HorseBoarding ToBoarding (BoardingDto dto)
        {
            return new HorseBoarding
            {
                HorseBoardingId = dto.BoardingId,
                Horse = HorseMapper.ToHorse(dto.Horse),
                BoardingEstate = EstateMapper.InfoToEstate(dto.Estate),
            };
        }
    }
}
