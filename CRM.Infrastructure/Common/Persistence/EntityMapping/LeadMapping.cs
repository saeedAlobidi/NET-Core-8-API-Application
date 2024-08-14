using CRM.Domain.Leads;
using Microsoft.EntityFrameworkCore;
 using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Common.Persistence.EntityMapping;

public class LeadsMapping : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
           builder.Property(lead => lead.Id)
            .ValueGeneratedOnAdd();

            
    }
}