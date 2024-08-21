using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.Region;
using WorkIn.Domain.Sorts.Region;

namespace WorkIn.Service.Contract
{
    public interface IRegionService
    {
        Task AddRegionAsync(Region region);
        Task<Region> GetRegionAsync(int regionId);
        Task<PagedModel<Region>> GetAllRegions(RegionFilter filter, RegionSort sort);
        Task UpdateRegionAsync(Region region);
        Task DeleteRegionAsync(int regionId);
        Task<PagedModel<Region>> GetAllRegionsNoFilter();
    }
}
