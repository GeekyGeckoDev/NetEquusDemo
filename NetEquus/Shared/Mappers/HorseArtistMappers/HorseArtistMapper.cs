using Application.EstateApp.EstateDtos;
using Domain.Entities.Models.EquineEstates;
using Domain.Entities.Models.Users;
using Shared.Dtos.HorseArtistDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Mappers.HorseArtistMappers
{
    public class HorseArtistMapper
    {
        public static HorseArtistDto ToDto(HorseArtist horseArtist)
        {
            return new HorseArtistDto
            {
                UserId = horseArtist.UserId,
                Username = horseArtist.User.Username,
                IsApproved = horseArtist.IsApproved,
            };
        }

        public static HorseArtist ToEntity(HorseArtistDto dto)
        {
            return new HorseArtist
            {
                UserId = dto.UserId,
                IsApproved = dto.IsApproved,

            };
        }
    }
}
