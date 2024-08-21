using Microsoft.AspNetCore.Http;
using System.Text.Json;
using WorkIn.Domain.Common;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Extensions;
using WorkIn.Persistence.MainRepository;
using WorkIn.Service.Contract;


namespace WorkIn.Service.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> countryRepository;

        public CountryService(IRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
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

        public async Task Upload(IFormFile file)
        {
            var country = countryRepository.GetAll();
            var countries = country.ToList();
            List<Country> countriesFromFile;

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string json = await reader.ReadToEndAsync();
                countriesFromFile = JsonSerializer.Deserialize<List<Country>>(json);
            }

            if (countriesFromFile == null)
            {
                throw new Exception("Failed to deserialize the uploaded file.");
            }

            var countriesFileIds = countriesFromFile.Select(x => x.Id).ToList();
            var deletedCountries = countries.Where(c => !countriesFileIds.Contains(c.Id)).ToList();

            foreach (var deletedCountry in deletedCountries)
            {
                deletedCountry.IsDeleted = true;
            }

            await countryRepository.UpdateAsync(deletedCountries, new string[] { "IsDeleted" });

            foreach (var item in countriesFromFile)
            {
                var updatedCountry = countries.FirstOrDefault(c => c.Id == item.Id);
                if (updatedCountry != null)
                {
                    updatedCountry.EnName = item.EnName;
                    updatedCountry.ArName = item.ArName;
                    await countryRepository.UpdateAsync(updatedCountry);
                }

            }

        }
    }
}