using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.City;
using WorkIn.Domain.Sorts.City;

namespace WorkIn.Service.Contract
{
    public interface ICityService
    {
        Task AddCityAsync(City city);
        Task<City> GetCityAsync(int cityId);
        Task<PagedModel<City>> GetAllCities(CityFilter filter, CitySort sort);
        Task UpdateCityAsync(City city);
        Task DeleteCityAsync(int cityId);
    }
}
