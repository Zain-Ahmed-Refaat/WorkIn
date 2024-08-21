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


    }
}
