using CRM.Domain.Applications;
using Microsoft.EntityFrameworkCore;
using CRM.Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace CRM.Infrastructure.Common.Persistence.EntityMapping;

public class RolePermission : IEntityTypeConfiguration<IdentityRoleClaim<int>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<int>> builder)
    {

        // add first system user
        builder.HasData(
            new IdentityRoleClaim<int>
        { 
             Id=1,
            RoleId = 1,
            ClaimType = "Permission",
            ClaimValue="lead.read"

        },
        new IdentityRoleClaim<int>
        { 
             Id=2,
            RoleId = 1,
            ClaimType = "Permission",
            ClaimValue="lead.write"

        }
        ,
        new IdentityRoleClaim<int>
        { 
            Id=3,
            RoleId = 1,
            ClaimType = "Permission",
            ClaimValue="service.read"

        }
        ,
        new IdentityRoleClaim<int>
        { 
            Id=4,
            RoleId = 1,
            ClaimType = "Permission",
            ClaimValue="service.write"

        }
        ,
        new IdentityRoleClaim<int>
        { 
            Id=5,
            RoleId = 1,
            ClaimType = "Permission",
            ClaimValue="application.read"

        }
        ,
        new IdentityRoleClaim<int>
        { 
            Id=6,
            RoleId = 1,
            ClaimType = "Permission",
            ClaimValue="application.write"

        },
        new IdentityRoleClaim<int>
        { 
            Id=7,
            RoleId = 1,
            ClaimType = "Permission",
            ClaimValue="user.read"

        }
        ,
        new IdentityRoleClaim<int>
        { 
            Id=8,
            RoleId = 1,
            ClaimType = "Permission",
            ClaimValue="user.write"

        });


    }
}