using Application.DbContext;
using Infrastructure.DTOs;
using Infrastructure.Usecase;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DbContexts.seed
{
    public  static class identity
    {

        public static async Task<Boolean> initAuthenticationAndAuthorization(UserManager<SystemUser> userManager, RoleManager<IdentityRole> roleManager, ISystemDbContext ctx)
        {
            var identityUsecase = new IdentityUsecase(userManager, roleManager, ctx);
            await identityUsecase.initRole();
            await identityUsecase.initPermisstion();
            return true;
        }


    }
}
