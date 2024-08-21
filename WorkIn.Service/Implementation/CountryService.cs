using Microsoft.AspNetCore.Http;
using System.Text.Json;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Extensions;
using WorkIn.Persistence.Data;
using WorkIn.Persistence.MainRepository;
using WorkIn.Service.Contract;


namespace WorkIn.Service.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> countryRepository;
        private readonly ApplicationDbContext context;

        public CountryService(IRepository<Country> countryRepository, ApplicationDbContext context)
        {
            this.countryRepository = countryRepository;
            this.context = context;
        }

        public async Task<PagedModel<Country>> GetAll(int page, int limit, string search)
        {
            var countries = await countryRepository.GetWhere(x => x.IsDeleted != true);
            countries = countries.Search(search);
            return countries.OrderBy(c => c.EnName).Paginate(page, limit);
        }

        public async Task<Country> Get(int id)
        {
            return await countryRepository.GetAsync(id);

        }

        public async Task AddCountryAsync(Country country)
        {
            if(country == null)
                return;

            if(country.ArName == null)

            if(country.EnName == null)

            await countryRepository.InsertAsync(country);
            await context.SaveChangesAsync();
        }
    }
}