using CRM.Domain.Applications;
using Microsoft.EntityFrameworkCore;
using CRM.Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace CRM.Infrastructure.Common.Persistence.EntityMapping;

public class UserMapping : IEntityTypeConfiguration<SystemUser>
{
    public void Configure(EntityTypeBuilder<SystemUser> builder)
    {

        var passwordHasher = new PasswordHasher<SystemUser>();

        var superUser = new SystemUser
        {

            Id = 1,
            UserName = "admin@example.com",
            Name = "Super admin",
            Email = "admin@example.com",
            NormalizedEmail ="admin@example.com".ToUpperInvariant(),
            EmailConfirmed=true,


        };
           // Generate a hashed password
        superUser.PasswordHash = passwordHasher.HashPassword(superUser, "saeed!123");

        // add first system user
        builder.HasData(superUser);


    }
}