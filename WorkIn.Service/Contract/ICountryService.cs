using Microsoft.AspNetCore.Http;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
namespace WorkIn.Service.Contract
{
    public interface ICountryService
    {
        Task<PagedModel<Country>> GetAll(int page, int limit, string search);
        Task<Country> Get(int id);
        Task AddCountryAsync(Country country);
    }
}
