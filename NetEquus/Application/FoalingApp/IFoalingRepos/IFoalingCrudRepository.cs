using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FoalingApp.IFoalingRepos
{
    public interface IFoalingCrudRepository
    {
        Task CreateFoalingAsync(Foaling foaling);
    }
}
