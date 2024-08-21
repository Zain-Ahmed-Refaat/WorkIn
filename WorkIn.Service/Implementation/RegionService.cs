using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.Region;
using WorkIn.Domain.Sorts.Region;
using WorkIn.Domain.Sorts;
using WorkIn.Persistence.Data;
using WorkIn.Persistence.MainRepository;
using WorkIn.Service.Contract;
using WorkIn.Domain.Extensions;

namespace WorkIn.Service.Implementation
{
    public class RegionService : IRegionService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository<Region> regionRepository;

        public RegionService(ApplicationDbContext context, IRepository<Region> regionRepository)
        {
            this.context = context;
            this.regionRepository = regionRepository;
        }

        public async Task AddRegionAsync(Region region)
        {
            region.ValidateRegion();

            await regionRepository.InsertAsync(region);
            await context.SaveChangesAsync();
        }

        public async Task<Region> GetRegionAsync(int regionId)
        {
            if (regionId <= 0)
                throw new ArgumentException("Invalid Region ID", nameof(regionId));

            var region = await regionRepository.GetAsync(regionId);
            if (region == null)
                throw new KeyNotFoundException($"Region with ID {regionId} not found.");

            return region;
        }

        public async Task<PagedModel<Region>> GetAllRegionsNoFilter()
        {
            var query = context.Regions.AsQueryable();
            var pagedModel = query.Paginate(1, 10); // Test with default pagination values
            return pagedModel;
        }


        public async Task<PagedModel<Region>> GetAllRegions(RegionFilter filter, RegionSort sort)
        {
            ValidateFilter(filter, sort);

            var query = context.Regions.AsQueryable();
            query = query.Filter(filter);
            query = query.Sort(sort);
            query = query.Search(filter.search);

            var pagedModel = query.Paginate(filter.page, filter.limit);
            return pagedModel;
        }

        private void ValidateFilter(RegionFilter filter, RegionSort sort)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
            if (sort == null)
                throw new ArgumentNullException(nameof(sort), "Sort cannot be null.");

            if (filter.page <= 0)
                filter.page = 1;

            if (filter.limit <= 0)
                filter.limit = 10;

            if (!Enum.IsDefined(typeof(RegionSortEnum), sort.orderKey))
                throw new ArgumentException("Invalid sort key.", nameof(sort.orderKey));

            if (!Enum.IsDefined(typeof(SortEnum), sort.orderDirection))
                throw new ArgumentException("Invalid sort direction.", nameof(sort.orderDirection));
        }

        public async Task UpdateRegionAsync(Region region)
        {
            region.ValidateRegionWithId();

            await regionRepository.UpdateAsync(region);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRegionAsync(int regionId)
        {
            if (regionId <= 0)
                throw new ArgumentException("RegionId must be greater than zero", nameof(regionId));

            var existingRegion = await regionRepository.GetAsync(regionId);
            if (existingRegion == null)
                throw new KeyNotFoundException($"No Region found with ID {regionId}");

            await regionRepository.DeleteAsync(existingRegion);
        }
    }
}
