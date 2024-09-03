using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.City;
using WorkIn.Domain.Sorts;
using WorkIn.Domain.Sorts.City;

namespace WorkIn.Domain.Extensions
{
    public static class CityExtensions
    {
        public static void ValidateCity(this City city)
        {
            if (city == null)
                throw new ArgumentException(nameof(city), "City cannot be null");


            if (string.IsNullOrWhiteSpace(city.ArName))
                throw new ArgumentException("City Arabic name (ArName) is required", nameof(city.ArName));


            if (string.IsNullOrWhiteSpace(city.EnName))
                throw new ArgumentException("City English name (EnName) is required", nameof(city.EnName));

            if (city.RegionId == null)
                throw new ArgumentException("Region ID is required", nameof(city.RegionId));
        }

        public static void ValidateCityWithId(this City city)
        {
            if (city == null)
                throw new ArgumentException(nameof(city), "City cannot be null");

            if (city.Id == null)
                throw new ArgumentException(nameof(city), "CityId cannot be null");

            if (string.IsNullOrWhiteSpace(city.ArName))
                throw new ArgumentException("City Arabic name (ArName) is required", nameof(city.ArName));


            if (string.IsNullOrWhiteSpace(city.EnName))
                throw new ArgumentException("City English name (EnName) is required", nameof(city.EnName));

            if (city.RegionId == null)
                throw new ArgumentException("Region ID is required", nameof(city.RegionId));
        }

        public static IQueryable<City> Filter(this IQueryable<City> cities, CityFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            if (filter.CityId.HasValue)
                cities = cities.Where(c => c.Id == filter.CityId.Value);

            if (!string.IsNullOrWhiteSpace(filter.ArName))
                cities = cities.Where(c => c.ArName.Contains(filter.ArName));

            if (!string.IsNullOrWhiteSpace(filter.EnName))
                cities = cities.Where(c => c.EnName.Contains(filter.EnName));

            if (filter.RegionId.HasValue)
                cities = cities.Where(c => c.RegionId == filter.RegionId.Value);

            if (filter.IsDeleted.HasValue)
                cities = cities.Where(c => c.IsDeleted == filter.IsDeleted.Value);

            return cities;
        }

        public static IQueryable<City> Sort(this IQueryable<City> cities, CitySort sort)
        {
            IOrderedQueryable<City> orderedCities;


            switch (sort.orderKey)
            {
                case CitySortEnum.CityId:
                    orderedCities = sort.orderDirection == SortEnum.OrderBy
                        ? cities.OrderBy(c => c.Id)
                        : cities.OrderByDescending(c => c.Id);
                    break;

                case CitySortEnum.ArName:
                    orderedCities = sort.orderDirection == SortEnum.OrderBy
                        ? cities.OrderBy(c => c.ArName)
                        : cities.OrderByDescending(c => c.ArName);
                    break;

                case CitySortEnum.EnName:
                    orderedCities = sort.orderDirection == SortEnum.OrderBy
                        ? cities.OrderBy(c => c.EnName)
                        : cities.OrderByDescending(c => c.EnName);
                    break;

                case CitySortEnum.RegionId:
                    orderedCities = sort.orderDirection == SortEnum.OrderBy
                        ? cities.OrderBy(c => c.RegionId)
                        : cities.OrderByDescending(c => c.RegionId);
                    break;

                default:
                    orderedCities = cities.OrderBy(c => c.Id);
                    break;
            }

            return orderedCities;
        }


        public static IQueryable<City> Search(this IQueryable<City> cities, string search)
        {
            if (string.IsNullOrEmpty(search))
                return cities;

            return cities
                .AsEnumerable()
                .Where(c => c.ArName.Contains(search, StringComparison.OrdinalIgnoreCase)
                         || c.EnName.Contains(search, StringComparison.OrdinalIgnoreCase)
                         || c.RegionId.ToString().Contains(search)
                         || (c.CreationDate.HasValue && c.CreationDate.Value.ToString("yyyy-MM-dd").Contains(search)))
                .AsQueryable();
        }

    }
}
