using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.Region;
using WorkIn.Domain.Sorts;
using WorkIn.Domain.Sorts.Region;

namespace WorkIn.Domain.Extensions
{
    public static class RegionExtensions
    {

        public static void ValidateRegion(this Region region)
        {
            if (region == null)
                throw new ArgumentException(nameof(region), "Region cannot be null");


            if (string.IsNullOrWhiteSpace(region.ArName))
                throw new ArgumentException("Region Arabic name (ArName) is required",
                    nameof(region.ArName));


            if (string.IsNullOrWhiteSpace(region.EnName))
                throw new ArgumentException("Region English name (EnName) is required",
                    nameof(region.EnName));

            if (region.CountryId == null)
                throw new ArgumentException("Country ID is required",
                    nameof(region.CountryId));
        }

        public static void ValidateRegionWithId(this Region region)
        {
            if (region == null)
                throw new ArgumentException(nameof(region), "Region cannot be null");

            if (region.Id == null)
                throw new ArgumentException(nameof(region), "RegionId cannot be null");

            if (string.IsNullOrWhiteSpace(region.ArName))
                throw new ArgumentException("Region Arabic name (ArName) is required",
                    nameof(region.ArName));

            if (string.IsNullOrWhiteSpace(region.EnName))
                throw new ArgumentException("Region English name (EnName) is required",
                    nameof(region.EnName));

            if (region.CountryId == null)
                throw new ArgumentException("Country ID is required",
                    nameof(region.CountryId));
        }

        public static IQueryable<Region> Filter(this IQueryable<Region> regions, RegionFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            if (!string.IsNullOrWhiteSpace(filter.ArName))
                regions = regions.Where(r => r.ArName.Contains(filter.ArName));

            if (!string.IsNullOrWhiteSpace(filter.EnName))
                regions = regions.Where(r => r.EnName.Contains(filter.EnName));

            if (filter.CountryId.HasValue)
                regions = regions.Where(r => r.CountryId == filter.CountryId.Value);

            return regions;
        }

        public static IQueryable<Region> Sort(this IQueryable<Region> regions, RegionSort sort)
        {
            IOrderedQueryable<Region> orderedRegions;

            switch (sort.orderKey)
            {
                case RegionSortEnum.ArName:
                    orderedRegions = sort.orderDirection == SortEnum.OrderBy
                        ? regions.OrderBy(r => r.ArName)
                        : regions.OrderByDescending(r => r.ArName);
                    break;

                case RegionSortEnum.EnName:
                    orderedRegions = sort.orderDirection == SortEnum.OrderBy
                        ? regions.OrderBy(r => r.EnName)
                        : regions.OrderByDescending(r => r.EnName);
                    break;

                case RegionSortEnum.CountryId:
                    orderedRegions = sort.orderDirection == SortEnum.OrderBy
                        ? regions.OrderBy(r => r.CountryId)
                        : regions.OrderByDescending(r => r.CountryId);
                    break;

                default:
                    orderedRegions = regions.OrderByDescending(r => r.Id);
                    break;
            }

            return orderedRegions;
        }

        public static IQueryable<Region> Search(this IQueryable<Region> regions, string search)
        {
            if (string.IsNullOrEmpty(search))
                return regions;

            return regions
                .AsEnumerable() 
                .Where(c => c.ArName.Contains(search, StringComparison.OrdinalIgnoreCase)
                         || c.EnName.Contains(search, StringComparison.OrdinalIgnoreCase)
                         || c.CountryId.ToString().Contains(search)
                         || (c.CreationDate.HasValue && c.CreationDate.Value.ToString("yyyy-MM-dd").Contains(search)))
                .AsQueryable();
        }


    }
}
