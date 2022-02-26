using Application.Constraints;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extenstion.Policy
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {

        public PermissionAuthorizationHandler()
        {

        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
            {
                return;
            }
            var permissionss = context.User.Claims.Where(x => x.Type == (ClaimsType.Permission.ToString()) &&
                                                            x.Value == requirement.Permission);
            if (permissionss.Any())
            {
                context.Succeed(requirement);
                return;
            }
            await Task.CompletedTask;
        }
    }
}