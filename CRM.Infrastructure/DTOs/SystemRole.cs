
using Microsoft.AspNetCore.Identity;

namespace CRM.Infrastructure.DTOs;

public class SystemRole : IdentityRole<int>
{


    public SystemRole() : base()
    { }
    public SystemRole(string roleName) : base(roleName)
    { }


}