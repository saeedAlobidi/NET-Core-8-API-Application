using CRM.Domain.Leads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Common.Persistence.EntityMapping;

public class CountriesMapping : IEntityTypeConfiguration<Countries>
{
    public void Configure(EntityTypeBuilder<Countries> builder)
    {

        builder.Property(country => country.Id)
         .ValueGeneratedOnAdd();

        builder.HasIndex(c => c.CountryCode)
          .IsUnique();


    }
}




public class TranslatedCountriesMapping : IEntityTypeConfiguration<TranslatedCountries>
{
    public void Configure(EntityTypeBuilder<TranslatedCountries> builder)
    {
         builder.Property(c => c.Id)
         .ValueGeneratedOnAdd();
 

    }
}

