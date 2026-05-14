using Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.HorseArtistApp.IHorseArtistRepos
{
    public interface IHorseArtistGetRepository
    {
        Task<List<HorseArtist>> GetArtistsByApprovalStatusAsync(bool isApproved);

        Task<HorseArtist> GetHorseArtistNyUserIdAsync(Guid artistId);
    }
}
