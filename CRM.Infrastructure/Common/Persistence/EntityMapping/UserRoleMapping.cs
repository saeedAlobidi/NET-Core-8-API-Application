using CRM.Domain.Applications;
using Microsoft.EntityFrameworkCore;
using CRM.Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace CRM.Infrastructure.Common.Persistence.EntityMapping;

public class UserRoleMapping : IEntityTypeConfiguration<IdentityUserRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
    {

        // add first system user
        builder.HasData(new IdentityUserRole<int>
        {
            RoleId = 1,
            UserId=1

        });


    }
}