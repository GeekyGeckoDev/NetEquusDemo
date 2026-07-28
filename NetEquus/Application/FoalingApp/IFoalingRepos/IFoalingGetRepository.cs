using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FoalingApp.IFoalingRepos
{
    public interface IFoalingGetRepository
    {
        Task<List<Foaling>> GetDueFoalingsAsync(Guid userId);
    }
}
