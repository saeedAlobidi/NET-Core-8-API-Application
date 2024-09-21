

using System.Text;
using CRM.Applications.Common.Interface;
using CRM.Infrastructure.Common.Interfaces;
using CRM.Infrastructure.Common.Persistence;
using CRM.Infrastructure.DTOs;
using CRM.Infrastructure.Persistence;
using CRM.Infrastructure.Utilities;
using CRM.Services.Common.Interface;
using Infrastructure.Common.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace CRM.Infrastructure;

public static class DependencyInjection
{

  

  public static IServiceCollection addInfrastructure(this IServiceCollection services, IOptions<databaseOption> dbOptions, IOptions<jwtOption> jwtOptions)
  {
    

  
    //epository
    services.AddScoped<ILeadRepository, LeadRepository>();
    services.AddScoped<IServicesRepository, ServicesRepository>();
    services.AddScoped<IApplicationsRepository, ApplicationRepository>();
    services.AddScoped<IUserRepository, UserRepository>();

    services.AddScoped(typeof(GenericRepository<>));

    // IUnit Of Work 
    services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<CRMManagementDbContext>());


    //database context
    services.AddDbContext<CRMManagementDbContext>(options =>
 {
   var connectionString = dbOptions.Value.connection;
   options.UseSqlServer(connectionString);
   //.LogTo(Console.WriteLine);


 });


    //AddIdentity
    services.AddIdentity<SystemUser, SystemRole>(options =>
            {
              options.Password.RequireDigit = false;
              options.Password.RequireUppercase = false;
              options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<CRMManagementDbContext>().AddDefaultTokenProviders();


    // // Configure JWT Authentication
    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })

    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtOptions.Value.Issuer,
        ValidAudience = jwtOptions.Value.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Key))
      };
    });

    services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
    services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
    services.AddScoped<JwtToken>();

    return services;
  }



}