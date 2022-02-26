using Application.DbContext;
using Domain.Entities.Customer;
using Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DbContexts
{
 public   class SystemDbContext : IdentityDbContext<SystemUser>,ISystemDbContext
    {
     
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
        {

        }
       
    
        // Tables
        public DbSet<Domain.Entities.Customer.Customer> Customer { get; set; }
       
      
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // you can check befor save here ^_*
            return await base.SaveChangesAsync();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.ToTable(name: "Users", "dbo");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles", "dbo");
            });
            modelBuilder.Entity<IdentityUserRole<String>>(entity =>
            {
                entity.ToTable("UserRoles", "dbo");
            });

            modelBuilder.Entity<IdentityUserClaim<String>>(entity =>
            {
                entity.ToTable("UserClaims", "dbo");
            });

            modelBuilder.Entity<IdentityUserLogin<String>>(entity =>
            {
                entity.ToTable("UserLogins", "dbo");
            });

            modelBuilder.Entity<IdentityRoleClaim<String>>(entity =>
            {
                entity.ToTable("RoleClaims", "dbo");
            });

            modelBuilder.Entity<IdentityUserToken<String>>(entity =>
            {
                entity.ToTable("UserTokens", "dbo");
            });


           
        }
    }
}