using Application.FoalingApp.IFoalingRepos;
using Application.FoalingApp.IFoalingServices;
using Domain.Entities.Models.Horses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FoalingApp.FoalingServices
{
    public class FoalingCrudService : IFoalingCrudService
    {
        private readonly IFoalingCrudRepository _repository;

        public FoalingCrudService(IFoalingCrudRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateFoalingAsync (Foaling foaling)
        {
            await _repository.CreateFoalingAsync(foaling);
        }
    }
}
