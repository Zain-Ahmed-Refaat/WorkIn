using Microsoft.EntityFrameworkCore;
using WorkIn.Domain.Entities;
using WorkIn.Infrastructure.Mapping.MapCity;
using WorkIn.Infrastructure.Mapping.MapCountry;
using WorkIn.Infrastructure.Mapping.MapDepartment;
using WorkIn.Infrastructure.Mapping.MapJobTitle;
using WorkIn.Infrastructure.Mapping.MapProfile;
using WorkIn.Infrastructure.Mapping.MapRegion;
using WorkIn.Infrastructure.Mapping.MapWorkInfo;
using WorkIn.Persistence.Data;
using WorkIn.Persistence.MainRepository;
using WorkIn.Service.Contract;
using WorkIn.Service.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
        maxRetryCount: 5,
        maxRetryDelay: TimeSpan.FromSeconds(30),
        errorNumbersToAdd: null)));



builder.Services.AddTransient<IRepository<Country>, Repository<Country>>();
builder.Services.AddTransient<IRepository<Region>, Repository<Region>>();
builder.Services.AddTransient<IRepository<City>, Repository<City>>();
builder.Services.AddTransient<IRepository<Department>, Repository<Department>>();
builder.Services.AddTransient<IRepository<JobTitle>, Repository<JobTitle>>();
builder.Services.AddTransient<IRepository<WorkInfo>, Repository<WorkInfo>>();
builder.Services.AddTransient<IRepository<Profile>, Repository<Profile>>();

builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IRegionService, RegionService>();
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IJobTitleService, JobTitleService>();
builder.Services.AddTransient<IWorkInfoService, WorkInfoService>();
builder.Services.AddTransient<IProfileService, ProfileService>();

builder.Services.AddAutoMapper(typeof(CityProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RegionProfile).Assembly);
builder.Services.AddAutoMapper(typeof(WorkInfoProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CountryProfile).Assembly);
builder.Services.AddAutoMapper(typeof(DepartmentProfile).Assembly);
builder.Services.AddAutoMapper(typeof(JobTitleProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ProfileProfile).Assembly);


builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
