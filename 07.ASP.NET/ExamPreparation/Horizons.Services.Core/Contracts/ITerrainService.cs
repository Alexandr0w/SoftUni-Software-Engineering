namespace Horizons.Services.Core.Contracts
{
    using Web.ViewModels.Destination;

    public interface ITerrainService
    {
        Task<IEnumerable<AddDestinationTerrainDropDownModel>> GetTerrainsDropDownAsync();
    }
}
