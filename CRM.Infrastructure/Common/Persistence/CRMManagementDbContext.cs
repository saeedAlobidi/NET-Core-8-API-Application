using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using CRM.Applications.Common.Interface;
using CRM.Domain.Applications;
using CRM.Domain.Leads;
using CRM.Domain.Services;
using CRM.Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Common.Persistence;

//public class GymManagementDbContext : DbContext, IUnitOfWork
public class CRMManagementDbContext : IdentityDbContext<SystemUser, SystemRole, int>
, IUnitOfWork

{

    public CRMManagementDbContext(DbContextOptions<CRMManagementDbContext> options)
       : base(options)
    {
    }
    public DbSet<Lead> Leads { get; set; }
    public DbSet<LeadSource> leadSources { get; set; }
    public DbSet<TranslatedLeadSource> translatedLeadSource { get; set; }

    public DbSet<LeadStatus> leadStatuse { get; set; }
    public DbSet<TranslatedLeadStatus> translatedLeadStatuses { get; set; }

    public DbSet<Countries> countries { get; set; }
    public DbSet<TranslatedCountries>  translatedCountries { get; set; }


    public DbSet<Service> Services { get; set; }
    public DbSet<Domain.Applications.Application> Applications { get; set; }



    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

    }
}