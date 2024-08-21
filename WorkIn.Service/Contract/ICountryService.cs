using Microsoft.AspNetCore.Http;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
namespace WorkIn.Service.Contract
{
    public interface ICountryService
    {
        public Task<PagedModel<Country>> GetAll(int page, int limit, string search);
        public Task<Country> Get(int id);
        public Task Upload(IFormFile file);
    }
}
