using Application.Constraints;
using Application.DbContext;
using Infrastructure.DbContexts;
using Infrastructure.DTOs;
using Infrastructure.Interfaces.Usecase;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Usecase
{
    public class IdentityUsecase : IIdentityUsecase
    {
        private UserManager<SystemUser> userManager;

        private RoleManager<IdentityRole> roleManager;
        ISystemDbContext ctx;
        public IdentityUsecase(UserManager<SystemUser> userManager, RoleManager<IdentityRole> roleManager, ISystemDbContext ctx)
        {
            this.userManager = userManager;

            this.roleManager = roleManager;
            this.ctx = ctx;
        }


        public async Task<Boolean> addPermission(IdentityRole role, List<string> Permissions)
        {
            var Claims = await roleManager.GetClaimsAsync(role);
            foreach (var permission in Permissions)
            {
                if (!Claims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim(ClaimsType.Permission.ToString(), permission));
                }
            }

            return true;
        }

        public async Task<IdentityResult> addRoles(IdentityRole data)
        {
            return await roleManager.CreateAsync(data);

        }



        public async Task<Boolean> initPermisstion()
        {


             
            var guestRole = await roleManager.FindByNameAsync(Roles.Guest.ToString());
            var adminRole = await roleManager.FindByNameAsync(Roles.Admin.ToString());
            var superAdminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());

            await addPermission(guestRole, new List<string> { GeneralPermisstions.Read.ToString() });
            await addPermission(adminRole, new List<string> { GeneralPermisstions.Read.ToString(), GeneralPermisstions.write.ToString() });
            await addPermission(superAdminRole, new List<string> { GeneralPermisstions.Read.ToString(), GeneralPermisstions.write.ToString(), GeneralPermisstions.delete.ToString() });
            return true;
        }

        public async Task<Boolean> initRole()
        {
            await addRoles(new IdentityRole(Roles.Guest.ToString()));
            await addRoles(new IdentityRole(Roles.Admin.ToString()));
            await addRoles(new IdentityRole(Roles.SuperAdmin.ToString()));
            return true;
        }




    }
}
