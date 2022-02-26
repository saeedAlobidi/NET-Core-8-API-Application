
using Infrastructure.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Infrastructure.DTOs;
using Infrastructure.Usecase;
using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Application.DbContext;
using System.Reflection;
using Infrastructure.Extenstion.Policy;

namespace Infrastructure.Dependency
{
 public static class DIServices
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<ISystemDbContext, SystemDbContext>();
        }
        public static void DbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SystemDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection")));
            services.AddIdentity<SystemUser, IdentityRole>(options =>
            { 
                
               
            }).AddEntityFrameworkStores<SystemDbContext>().AddDefaultTokenProviders();

          
        }

        public static void AddPolicyServices(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        }
        public static void Repositories(this IServiceCollection services)
        {

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
                            
            services.AddTransient<Application.Interfaces.Repositories.ICustomer, Infrastructure.Repositories.Customer>();

        }

        public static void Usecase(this IServiceCollection services)
        {

            services.AddTransient<Infrastructure.Interfaces.Usecase.ICustomerUsecase, Infrastructure.Usecase.CustomerUsecase>();
            services.AddTransient<Infrastructure.Interfaces.Usecase.IIdentityUsecase, Infrastructure.Usecase.IdentityUsecase>();

        }

    }





}
