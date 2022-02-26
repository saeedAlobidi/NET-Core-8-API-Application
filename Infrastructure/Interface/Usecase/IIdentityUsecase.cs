using Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Usecase
{
    public interface IIdentityUsecase
    {
        public Task<Boolean> initRole();
        public Task<Boolean> initPermisstion();
       
        public Task<IdentityResult> addRoles(IdentityRole data);
        public Task<Boolean> addPermission(IdentityRole role, List<string> Permissions);
    }
}
