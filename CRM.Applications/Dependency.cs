

using Microsoft.Extensions.DependencyInjection;

namespace CRM.Applications;

public static class DependencyInjection
{
  public static IServiceCollection addApplication(this IServiceCollection services)
    {
        
        services.AddMediatR(options=>{
          options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
        });
        return services;
    }
}