//using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Contexts;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Infrastructure.Interfaces;
using ReservationProject.Infrastructure.Repositories;
using ReservationProject.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ReservationProject.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IServiceModalRepository, ServiceModalRepository>();
            services.AddTransient<IServicePolicyRepository, ServicePolicyRepository>();
            services.AddTransient<IServicePolicyItemRepository, ServicePolicyItemRepository>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IAvailableServiceRepository, AvailableServiceRepository>();
            services.AddTransient<IAvailableServiceTimeRepository, AvailableServiceTimeRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<ITemporaryReservationRepository, TemporaryReservationRepository>();
            services.AddTransient<IRateRepository, RateRepository>();
          


            // adding all Reposttories 

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IServiceModalService, ServiceModalService>(); 
            services.AddTransient<IServicePolicyService, ServicePolicyService>();
            services.AddTransient<IServicePolicyItemService, ServicePolicyItemService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<IAvailableServiceService, AvailableServiceService>();
            services.AddTransient<IAvailableServiceTimeService, AvailableServiceTimeService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ITemporaryReservationService, TemporaryReservationService>();
            services.AddTransient<IRateService, RateService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion Repositories
        }

        public static void AddIdentityPermissionServices(this IServiceCollection services)
        {
            // services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            // services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        }

        public static void AddCrudServices(this IServiceCollection services)
        {
            //services.AddTransient<IProjectService, ProjectService>();
            //services.AddTransient<IRoleService, RoleService>();
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<ITaskListService, TaskListService>();
            //services.AddTransient<IUserAssignToService, UserAssignToService>();
            //services.AddTransient<IKanbanService, KanbanService>();
            //services.AddTransient<ITaskService, TaskService>();
            //services.AddTransient<IMyTaskService, MyTaskService>();
            //services.AddTransient<IReportService, ReportService>();
            //services.AddTransient<ITrackService, TrackService>();
            //services.AddTransient<IDiscussionService, DiscussionService>();
            //services.AddTransient<IIdentityService, IdentityService>();
        }

        public static void AddSharedInfrastructure(this IServiceCollection services)
        {
            //services.AddTransient<IDateTimeService, SystemDateTimeService>();
            //services.AddTransient<IAuthenticatedUserService, AuthenticatedUserService>();
        }

        public static void AddJsonLocalization(this IServiceCollection services)
        {
            //services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            //services.AddSingleton<LocalizationMiddleware>();
            //services.AddLocalization();
        }
    }
}
