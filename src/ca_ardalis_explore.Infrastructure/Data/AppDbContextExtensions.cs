namespace ca_ardalis_explore.Infrastructure.Data;

using Npgsql.EntityFrameworkCore.PostgreSQL;

public static class AppDbContextExtensions
{
  public static void AddApplicationDbContext(this IServiceCollection services, string connectionString) =>
    services.AddDbContext<AppDbContext>(options =>
         options.UseNpgsql(connectionString));

}
