using WorkIn.Domain.Entities;

namespace WorkIn.Domain.Extensions
{
    public static class CountryExtension
    {

        public static IQueryable<Country> Search(this IQueryable<Country> countries, string search)
        {
            return countries = countries.Where(c => c.EnName.Contains(search)
            || c.ArName.Contains(search)
            || string.IsNullOrEmpty(search));
        }

        public static void ValidateCountry(this Country country)
        {

            if(country == null)
                throw new ArgumentNullException(nameof(country), "Cannot Be Null");

            if(country.ArName == null)
                throw new ArgumentNullException(nameof(country.ArName), "Cannot Be Null");

            if (country.EnName == null)
                throw new ArgumentNullException(nameof(country.EnName), "Cannot Be Null");

        }
    }
}
