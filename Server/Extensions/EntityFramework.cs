using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Context;

namespace Server.Extensions {
  public static partial class Extensions {
    public static IServiceCollection SetEntityFramework(this IServiceCollection services, IConfiguration configuration) =>
      services.AddDbContext<DataContext>(options => options
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging()
        .UseSqlServer(configuration.GetConnectionString("Default")));
  }
}