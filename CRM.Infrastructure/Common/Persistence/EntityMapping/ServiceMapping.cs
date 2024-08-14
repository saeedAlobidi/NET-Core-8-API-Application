using CRM.Domain.Services;
using Microsoft.EntityFrameworkCore;
 using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Common.Persistence.EntityMapping;

public class ServicesMapping : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
           builder.Property(sv => sv.Id)
            .ValueGeneratedOnAdd();

            
    }
}