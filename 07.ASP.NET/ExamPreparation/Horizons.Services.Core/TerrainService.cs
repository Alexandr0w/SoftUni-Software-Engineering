namespace Horizons.Services.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Services.Core.Contracts;
    using Data;
    using Web.ViewModels.Destination;

    public class TerrainService : ITerrainService
    {
        private readonly HorizonsDbContext _dbContext;

        public TerrainService(HorizonsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<AddDestinationTerrainDropDownModel>> GetTerrainsDropDownAsync()
        {
            IEnumerable<AddDestinationTerrainDropDownModel> terrainsAsDropdown = await this._dbContext
                .Terrains
                .AsNoTracking()
                .Select(t => new AddDestinationTerrainDropDownModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToArrayAsync();

            return terrainsAsDropdown;
        }
    }
}
