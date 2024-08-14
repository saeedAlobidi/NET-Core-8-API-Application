using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using CRM.Applications.Common.Interface;
using CRM.Domain.Applications;
using CRM.Domain.Leads;
using CRM.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Common.Persistence;

//public class GymManagementDbContext : DbContext, IUnitOfWork
public class CRMManagementDbContext : DbContext, IUnitOfWork

{
    public DbSet<Domain.Leads.Lead> Leads { get; set; }
    public DbSet<Domain.Services.Service> Services { get; set; }
    public DbSet<Domain.Applications.Application> Applications { get; set; }
    public CRMManagementDbContext(DbContextOptions<CRMManagementDbContext> options)
        : base(options)
    {
    }
 

    public async Task CommitChangesAsync()
    {
          await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
 
    }
}