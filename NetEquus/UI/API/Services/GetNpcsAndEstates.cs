using Shared.Dtos.OwnershipDtos;
using UI.API.Clients;

namespace UI.API.Services
{
    public class GetNpcsAndEstates
    {
        private readonly NpcClient _npcClient;

        private readonly EstateOwnershipClient _estateOwnershipClient;

        public GetNpcsAndEstates(NpcClient npcClient, EstateOwnershipClient estateOwnershipClient)
        {
            _npcClient = npcClient;
            _estateOwnershipClient = estateOwnershipClient;
        }

        public async Task<List<EstateOwnershipDto>> GetNpcAndEstate()
        {
            var npcs = await _npcClient.GetNpcsWithoutEstatesAsync();

            var tasks = npcs.Select(async npc =>
            {
                var ownership = await _estateOwnershipClient
                    .GetEstateOwnershipsByUserId(npc.UserId);

                return new EstateOwnershipDto
                {
                    UserId = npc.UserId,
                    EquineEstateId = ownership?.EquineEstateId
                };

            });

            var results = await Task.WhenAll(tasks);

            return results.ToList();
        }
    }
}
