
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Extension;
public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{

    public PermissionAuthorizationHandler()
    {

    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {

        var permissionss = context.User.Claims.Where(x => x.Type == ("Permission") && x.Value == requirement.Permission);
        
        if (permissionss.Any())
        {
            context.Succeed(requirement);
            return;
        }
        await Task.CompletedTask;
    }
    
}
