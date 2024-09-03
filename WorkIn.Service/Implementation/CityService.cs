using Microsoft.EntityFrameworkCore;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Extensions;
using WorkIn.Domain.Filters.City;
using WorkIn.Domain.Sorts;
using WorkIn.Domain.Sorts.City;
using WorkIn.Persistence.Data;
using WorkIn.Persistence.MainRepository;
using WorkIn.Service.Contract;

namespace WorkIn.Service.Implementation
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository<City> cityRepository;

        public CityService(ApplicationDbContext context, IRepository<City> cityRepository)
        {
            this.context = context;
            this.cityRepository = cityRepository;
        }

        public async Task AddCityAsync(City city)
        {
            city.ValidateCity();

            var existingCity = await context.Cities.FirstOrDefaultAsync(c => c.EnName == city.EnName && c.ArName == city.ArName);
            if (existingCity != null)
                throw new ArgumentException($"A City with the name '{city.EnName}' already exists.");

            await cityRepository.InsertAsync(city);
            await context.SaveChangesAsync();
        }

        public async Task<City> GetCityAsync(int cityId)
        {
            if (cityId <= 0)
                throw new ArgumentException("Invalid city ID", nameof(cityId));

            var city = await cityRepository.GetAsync(cityId);
            if (city == null)
                throw new KeyNotFoundException($"City with ID {cityId} not found.");

            return city;
        }

        public async Task<PagedModel<City>> GetAllCities(CityFilter filter, CitySort sort)
        {
            ValidateFilter(filter, sort);

            var query = context.Cities.AsQueryable();
            query = query.Filter(filter);
            query = query.Sort(sort);
            query = query.Search(filter.search);

            var pagedModel = query.Paginate(filter.page, filter.limit);
            return pagedModel;
        }

        private void ValidateFilter(CityFilter filter, CitySort sort)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
            if (sort == null)
                throw new ArgumentNullException(nameof(sort), "Sort cannot be null.");

            if (filter.page <= 0)
                filter.page = 1;

            if (filter.limit <= 0)
                filter.limit = 10;

            if (!Enum.IsDefined(typeof(CitySortEnum), sort.orderKey))
                throw new ArgumentException("Invalid sort key.", nameof(sort.orderKey));

            if (!Enum.IsDefined(typeof(SortEnum), sort.orderDirection))
                throw new ArgumentException("Invalid sort direction.", nameof(sort.orderDirection));
        }

        public async Task UpdateCityAsync(City city)
        {
            city.ValidateCityWithId();

            var c = await context.Cities.FindAsync(city.RegionId);

            if (c == null)
                throw new Exception("Region Id NotFound");

            await cityRepository.UpdateAsync(city);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCityAsync(int cityId)
        {
            if (cityId <= 0)
                throw new ArgumentException("CityId must be greater than zero", nameof(cityId));

            var existingCity = await cityRepository.GetAsync(cityId);
            if (existingCity == null)
                throw new KeyNotFoundException($"No city found with ID {cityId}");

            await cityRepository.DeleteAsync(existingCity);
        }

    }
}
