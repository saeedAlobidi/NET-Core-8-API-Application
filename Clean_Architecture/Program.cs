using Application.DbContext;
using Infrastructure.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean_Architecture
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<SystemUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var ISystemDbContext = services.GetRequiredService<ISystemDbContext>();

                await Infrastructure.DbContexts.seed.identity.initAuthenticationAndAuthorization(userManager, roleManager, ISystemDbContext);

            }
            host.Run();
        }

       

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
