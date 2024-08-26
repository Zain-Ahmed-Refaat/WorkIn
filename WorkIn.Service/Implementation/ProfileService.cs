using WorkIn.Domain.Common;
using ProfileEntity = WorkIn.Domain.Entities.Profile;
using WorkIn.Domain.Extensions;
using WorkIn.Domain.Sorts;
using WorkIn.Persistence.Data;
using WorkIn.Service.Contract;
using WorkIn.Persistence.MainRepository;
using WorkIn.Domain.Filters.Profile;
using WorkIn.Domain.Sorts.ProfileSort;

namespace WorkIn.Service.Implementation
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository<ProfileEntity> profileRepository;

        public ProfileService(ApplicationDbContext context, IRepository<ProfileEntity> profileRepository)
        {
            this.context = context;
            this.profileRepository = profileRepository;
        }

        public async Task AddProfileAsync(ProfileEntity profile)
        {
            profile.ValidateProfile();

            var existingCity = await context.Cities.FindAsync(profile.CityId);
            if (existingCity == null)
                throw new ArgumentException($"There is No Country with Id: {profile.CityId}");

            var existingDepartment = await context.Departments.FindAsync(profile.DepartmentId);
            if (existingDepartment == null)
                throw new ArgumentException($"There is No Department with Id: {profile.DepartmentId}");

            await profileRepository.InsertAsync(profile);
            await context.SaveChangesAsync();
        }

        public async Task<ProfileEntity> GetProfileAsync(int profileId)
        {
            if (profileId <= 0)
                throw new ArgumentException("Invalid Profile ID", nameof(profileId));

            var profile = await profileRepository
                .GetIncludingAsync(profileId,
                                    [
                                        p => p.Manager,
                                        p => p.City,
                                        p => p.City.Region,
                                        p => p.City.Region.Country,
                                        p => p.Department
                                    ]);


            if (profile == null)
                throw new KeyNotFoundException($"Profile with ID {profileId} not found.");
            return profile;
        }

        public async Task<PagedModel<ProfileEntity>> GetAllProfilesNoFilter()
        {
            var query = context.Profiles.AsQueryable();
            var pagedModel = query.Paginate(1, 10);
            return pagedModel;
        }


        public async Task<PagedModel<ProfileEntity>> GetAllProfiles(ProfileFilter filter, ProfileSort sort)
        {
            ValidateFilter(filter, sort);

            var query = context.Profiles.AsQueryable();
            query = query.Filter(filter);
            query = query.Sort(sort);
            query = query.Search(filter.search);

            var pagedModel = query.Paginate(filter.page, filter.limit);
            return pagedModel;
        }

        private void ValidateFilter(ProfileFilter filter, ProfileSort sort)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
            if (sort == null)
                throw new ArgumentNullException(nameof(sort), "Sort cannot be null.");

            if (filter.page <= 0)
                filter.page = 1;

            if (filter.limit <= 0)
                filter.limit = 10;

            if (!Enum.IsDefined(typeof(ProfileSortEnum), sort.OrderKey))
                throw new ArgumentException("Invalid sort key.", nameof(sort.OrderKey));

            if (!Enum.IsDefined(typeof(SortEnum), sort.OrderDirection))
                throw new ArgumentException("Invalid sort direction.", nameof(sort.OrderDirection));
        }

        public async Task UpdateProfileAsync(ProfileEntity profile)
        {
            profile.ValidateProfileWithID();

            await profileRepository.UpdateAsync(profile);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProfileAsync(int profileId)
        {
            if (profileId <= 0)
                throw new ArgumentException("ProfileId must be greater than zero", nameof(profileId));

            var existingProfile = await profileRepository.GetAsync(profileId);
            if (existingProfile == null)
                throw new KeyNotFoundException($"No Profile found with ID {profileId}");

            await profileRepository.DeleteAsync(existingProfile);
        }

    }
}
