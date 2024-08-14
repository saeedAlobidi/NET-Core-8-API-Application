

using CRM.Applications.Common.Interface;
using CRM.Infrastructure.Common.Interfaces;
using CRM.Infrastructure.Common.Persistence;
using CRM.Infrastructure.Persistence;
using CRM.Services.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CRM.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection addInfrastructure(this IServiceCollection services)
  {
    services.AddScoped<ILeadRepository, LeadRepository>();
    services.AddScoped<IServicesRepository, ServicesRepository>();
    services.AddScoped<IApplicationsRepository, ApplicationRepository>();
    services.AddDbContext<CRMManagementDbContext>(options =>
 {
   var connectionString = "Data Source=localhost; Initial Catalog=CRMDB; User Id=mms; Password=mms; TrustServerCertificate=True;";
   options.UseSqlServer(connectionString);
        // .LogTo(Console.WriteLine);
 });


    services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<CRMManagementDbContext>());
    services.AddScoped(typeof(GenericRepository<>));

    return services;
  }



}