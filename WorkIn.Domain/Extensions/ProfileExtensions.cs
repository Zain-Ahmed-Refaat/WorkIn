using System.Text.RegularExpressions;
using WorkIn.Domain.Entities;
using WorkIn.Domain.Filters.Profile;
using WorkIn.Domain.Sorts.ProfileSort;
using WorkIn.Domain.Sorts;

namespace WorkIn.Domain.Extensions
{
    public static class ProfileExtensions
    {
        public static void ValidateProfile(this Profile profile)
        { 
            if (string.IsNullOrWhiteSpace(profile.Name))            
                throw new ArgumentException("Name is required.");
            

            if (string.IsNullOrWhiteSpace(profile.Email))
                throw new ArgumentException("Email is required.");
            

            if (profile.DepartmentId == null)           
                throw new ArgumentException("DepartmentId is required.");
            

            if (profile.CityId == null)            
                throw new ArgumentException("CountryId is required.");
            
            
            if (!string.IsNullOrWhiteSpace(profile.PhoneNumber) && !IsValidPhoneNumber(profile.PhoneNumber))
                throw new ArgumentException("Invalid phone number format.");

        }
        public static void ValidateProfileWithID(this Profile profile)
        { 

            if (profile.Id == null)
                throw new ArgumentNullException("Id Cannot be null");
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\+?[1-9]\d{1,14}$");
        }

        public static IQueryable<Profile> Filter(this IQueryable<Profile> profiles, ProfileFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            if (filter.Id > 0)
                profiles = profiles.Where(p => p.Id == filter.Id);

            if (filter.ManagerId.HasValue)
                profiles = profiles.Where(p => p.ManagerId == filter.ManagerId.Value);

            if (filter.DepartmentId.HasValue)
                profiles = profiles.Where(p => p.DepartmentId == filter.DepartmentId.Value);

            if (filter.CityId.HasValue)
                profiles = profiles.Where(p => p.CityId == filter.CityId.Value);

            if (!string.IsNullOrWhiteSpace(filter.Name))
                profiles = profiles.Where(p => p.Name.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.JobTitle))
                profiles = profiles.Where(p => p.JobTitle.Contains(filter.JobTitle));

            if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
                profiles = profiles.Where(p => p.PhoneNumber.Contains(filter.PhoneNumber));

            if (!string.IsNullOrWhiteSpace(filter.Email))
                profiles = profiles.Where(p => p.Email.Contains(filter.Email));

            return profiles;
        }


        public static IQueryable<Profile> Sort(this IQueryable<Profile> profiles, ProfileSort sort)
        {
            if (sort == null)
                throw new ArgumentNullException(nameof(sort));

            IOrderedQueryable<Profile> orderedProfiles;

            switch (sort.OrderKey)
            {
                case ProfileSortEnum.Id:
                    orderedProfiles = sort.OrderDirection == SortEnum.OrderBy
                        ? profiles.OrderBy(p => p.Id)
                        : profiles.OrderByDescending(p => p.Id);
                    break;

                case ProfileSortEnum.Name:
                    orderedProfiles = sort.OrderDirection == SortEnum.OrderBy
                        ? profiles.OrderBy(p => p.Name)
                        : profiles.OrderByDescending(p => p.Name);
                    break;

                case ProfileSortEnum.JobTitle:
                    orderedProfiles = sort.OrderDirection == SortEnum.OrderBy
                        ? profiles.OrderBy(p => p.JobTitle)
                        : profiles.OrderByDescending(p => p.JobTitle);
                    break;

                case ProfileSortEnum.DepartmentId:
                    orderedProfiles = sort.OrderDirection == SortEnum.OrderBy
                        ? profiles.OrderBy(p => p.DepartmentId)
                        : profiles.OrderByDescending(p => p.DepartmentId);
                    break;

                case ProfileSortEnum.CityId:
                    orderedProfiles = sort.OrderDirection == SortEnum.OrderBy
                        ? profiles.OrderBy(p => p.CityId)
                        : profiles.OrderByDescending(p => p.CityId);
                    break;

                case ProfileSortEnum.ManagerId:
                    orderedProfiles = sort.OrderDirection == SortEnum.OrderBy
                        ? profiles.OrderBy(p => p.ManagerId)
                        : profiles.OrderByDescending(p => p.ManagerId);
                    break;

                default:
                    orderedProfiles = profiles.OrderByDescending(p => p.Id);
                    break;
            }

            return orderedProfiles;
        }

        public static IQueryable<Profile> Search(this IQueryable<Profile> profiles, string search)
        {
            if (string.IsNullOrEmpty(search))
                return profiles;

            return profiles
                .AsEnumerable()
                .Where(p =>
                       p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || p.JobTitle.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || p.PhoneNumber.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || p.Email.Contains(search, StringComparison.OrdinalIgnoreCase))
                .AsQueryable();
        }


    }
}
