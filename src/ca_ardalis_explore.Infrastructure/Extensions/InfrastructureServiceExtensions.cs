using ca_ardalis_explore.Core.Identity;
using ca_ardalis_explore.Infrastructure.Data;
using ca_ardalis_explore.Infrastructure.Data.Queries;
using ca_ardalis_explore.UseCases.Contributors.List;
using Npgsql.EntityFrameworkCore.PostgreSQL;

using Microsoft.AspNetCore.Identity;
using ca_ardalis_explore.Core.Services.Contibutors;
using ca_ardalis_explore.Core.Interfaces.Contributors;

using ca_ardalis_explore.Infrastructure.Services.Identity;


namespace ca_ardalis_explore.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("DefaultConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options =>
     options.UseNpgsql(connectionString));

    // Register Identity with custom user and role
    //services.AddIdentity<ApplicationUser, ApplicationRole>();
    services.AddIdentityApiEndpoints<ApplicationUser>()
      .AddRoles<ApplicationRole>()
      .AddEntityFrameworkStores<AppDbContext>()
      .AddDefaultTokenProviders();
    
    
    services.AddAuthorization();



    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
           .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>))
           .AddScoped<IListContributorsQueryService, ListContributorsQueryService>()
           .AddScoped<IDeleteContributorService, DeleteContributorService>();

    services.AddScoped<IUserManagementService, UserManagementService>();



    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
