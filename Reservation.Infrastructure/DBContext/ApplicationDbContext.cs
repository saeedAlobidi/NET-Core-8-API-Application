
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Reservation.Infrastructure.Models.Identity;
using ReservationProject.Application.Interfaces.Shared;
using ReservationProject.Application.Interfaces.Contexts;
using ReservationProject.Domain.Common;
using ReservationProject.Domain.Entities.Cateogry;
using ReservationProject.Domain.Entities.AvailableService;
using ReservationProject.Domain.Entities.AvailableServiceTime; 
using ReservationProject.Domain.Entities.ServicePolicy;
using ReservationProject.Domain.Entities.ServicePolicyItem;
using ReservationProject.Domain.Entities.ServiceModal;
using ReservationProject.Infrastructure.Extensions;
using ReservationProject.Domain.Entities.Discount;
using ReservationProject.Domain.Entities.Location;
using ReservationProject.Domain.Entities.TemporaryReservation;
using ReservationProject.Domain.Entities.Rate;

namespace Reservation.Infrastructure.DBContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> , IApplicationDbContext
    {
         private readonly IDateTimeService _dateTime;
         private readonly IAuthenticatedUserService _authenticatedUser;
         
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
         {
           _dateTime = dateTime;
           _authenticatedUser = authenticatedUser;

         }

        public IDbConnection Connection => Database.GetDbConnection();
        public bool HasChanges => ChangeTracker.HasChanges();


        // Tables
        public DbSet<Category> Cateogries { get; set; }
        public DbSet<AvailableService> AvailableServices { get; set; }
        public DbSet<AvailableServiceTime> AvailableServiceTime { get; set; }

        // Service 
        public DbSet<ServiceModal> ServiceModal { get; set; }
        public DbSet<ServicePolicy> ServicePolicy { get; set; }
        public DbSet<ServicePolicyItem> ServicePolicyItem { get; set; }

        // Discount 
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Location> Locations { get; set; }

        // Reservation
        public DbSet<TemporaryReservation> TemporaryReservations { get; set; }
        public DbSet<Rate> Rate { get; set; }

       
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity is ICreationEntity creationEntity)
                        {

                            creationEntity.CreatedOn = _dateTime.NowUtc;
                            creationEntity.CreatedBy = _authenticatedUser.UserId;
                        }
                        break;
                    case EntityState.Modified:
                        if (entry.Entity is IAuditableEntity auditionEntity)
                        { 
                            auditionEntity.LastModifiedOn = _dateTime.NowUtc;
                            auditionEntity.LastModifiedBy = _authenticatedUser.UserId; 
                        }
                        break;

                    case EntityState.Deleted:
                        if (entry.Entity is ISoftDelete softDelete)
                        {
                            softDelete.Is_Deleted = true;
                            softDelete.deleteTime = _dateTime.NowUtc;
                            softDelete.UserId = _authenticatedUser.UserId;

                            entry.State = EntityState.Modified;
                        }
                        break;
                }
            }
            if (_authenticatedUser.UserId == null)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            else
            {

                return await base.SaveChangesAsync();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }

            base.OnModelCreating(builder);
            //Global Query Filter 
            
            builder.ApplyGlobalFilters<ISoftDelete>(s => s.Is_Deleted == false);
            
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users", "dbo");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles", "dbo");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "dbo");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "dbo");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "dbo");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims", "dbo");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "dbo");
            });


        }
        

    }
}
