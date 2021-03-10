using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Extensions;
using Server.Helpers;

namespace Server {
  public class Startup {
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) => Configuration = configuration;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) => services
      .SetEntityFramework(Configuration)
      .AddScoped<ICalculatorRepository, CalculatorRepository>()
      .SetIdentity()
      .SetControllers()
      .SetSwaggerDocs()
      .AddCors();

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder builder, IWebHostEnvironment env) => builder
      .UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())
      .UseDeveloperExceptionPage()
      .UseRouting()
      .UseAuthentication()
      .UseAuthorization()
      .UseSwaggerDocs()
      .UseEndpoints(endpoints => endpoints.MapControllers());
  }
}