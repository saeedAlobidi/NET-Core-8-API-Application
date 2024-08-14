using CRM.Domain.Applications;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Common.Persistence.EntityMapping;

public class ApplicationMapping : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
           builder.Property(app => app.Id)
            .ValueGeneratedOnAdd();

            
    }
}