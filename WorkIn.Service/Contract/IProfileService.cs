using WorkIn.Domain.Common;
using WorkIn.Domain.Filters.Profile;
using WorkIn.Domain.Sorts.ProfileSort;
using ProfileEntity = WorkIn.Domain.Entities.Profile;

namespace WorkIn.Service.Contract
{
    public interface IProfileService
    {
        Task AddProfileAsync(ProfileEntity profile);
        Task<ProfileEntity> GetProfileAsync(int profileId);
        Task<PagedModel<ProfileEntity>> GetAllProfilesNoFilter();
        Task<PagedModel<ProfileEntity>> GetAllProfiles(ProfileFilter filter, ProfileSort sort);
        Task UpdateProfileAsync(ProfileEntity profile);
        Task DeleteProfileAsync(int profileId);
    }
}
