using Microsoft.EntityFrameworkCore;
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
            if (id == 0) 
                throw new ArgumentException(nameof(id), "Cannot Be Null");

            return await countryRepository.GetAsync(id);
        }

        public async Task AddCountryAsync(Country country)
        {
            country.ValidateCountry();

            var existingCountry = await context.Countries.FirstOrDefaultAsync(c => c.EnName == country.EnName && c.ArName == country.ArName);
            if (existingCountry != null)
                throw new ArgumentException($"A country with the name '{country.EnName}' already exists.");

            await countryRepository.InsertAsync(country);
            await context.SaveChangesAsync();
        }

    }
}