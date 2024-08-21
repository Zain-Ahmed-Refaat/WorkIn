using Microsoft.EntityFrameworkCore;
using WorkIn.Domain.Entities;

namespace WorkIn.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Profile> Profiles{ get; set; }
        public DbSet<WorkInfo> WorkInfos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
