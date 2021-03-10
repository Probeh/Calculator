using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Server.Context;
using Server.Models;

namespace Server.Extensions {
  public static partial class Extension {
    public static IServiceCollection SetIdentity(this IServiceCollection services) =>
      services
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme).Services
      .AddDefaultIdentity<User>(options => {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.User.RequireUniqueEmail = false;
      })
      .AddRoles<Role>()
      .AddEntityFrameworkStores<DataContext>()
      .AddRoleManager<RoleManager<Role>>()
      .AddRoleValidator<RoleValidator<Role>>()
      .AddUserManager<UserManager<User>>()
      .AddSignInManager<SignInManager<User>>()
      .Services
      .AddAuthorization(options => options.AddPolicy("ElevatedRights", policy => policy.RequireRole("Administrator")));
  }
}