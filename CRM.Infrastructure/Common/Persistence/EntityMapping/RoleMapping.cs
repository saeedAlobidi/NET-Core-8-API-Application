using CRM.Domain.Applications;
using Microsoft.EntityFrameworkCore;
using CRM.Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace CRM.Infrastructure.Common.Persistence.EntityMapping;

public class RoleMapping : IEntityTypeConfiguration<SystemRole>
{
    public void Configure(EntityTypeBuilder<SystemRole> builder)
    {

        // add first system user
        builder.HasData(new SystemRole
        {
            Id = 1,

            Name = "SuperAdmin"

        });


    }
}