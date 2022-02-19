using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Interfaces.Shared;
using ReservationProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly ApplicationDbContext _dbContext;
        private bool disposed;
 
        public ICategoryRepository CategoryRepository { get; private set; }
        public IServiceModalRepository ServiceModalRepository { get; private set; }
        public IServicePolicyRepository ServicePolicyRepository { get; private set; }
        public IServicePolicyItemRepository ServicePolicyItemRepository { get; private set; }
        public IDiscountRepository DiscountRepository { get; private set; }

        public IAvailableServiceRepository AvailableServiceRepository { get; private set; }

        public IAvailableServiceTimeRepository AvailableServiceTimeRepository { get; private set; }
        public ILocationRepository LocationRepository { get; private set; }

        public ITemporaryReservationRepository TemporaryReservationRepository { get; private set; }
        public IRateRepository RateRepository { get; private set; }


        //  
        public UnitOfWork(ApplicationDbContext dbContext, IAuthenticatedUserService authenticatedUserService, 
            ICategoryRepository cateogryRepository ,
            IServiceModalRepository serviceModalRepository,
             IServicePolicyRepository servicePolicyRepository,
             IServicePolicyItemRepository servicePolicyItemRepository,
             IDiscountRepository discountRepository,
             IAvailableServiceRepository availableServiceRepository,
             IAvailableServiceTimeRepository availableServiceTimeRepository,
             ILocationRepository locationRepository,
             ITemporaryReservationRepository temporaryReservationRepository,
             IRateRepository rateRepository 
            )
            {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _authenticatedUserService = authenticatedUserService;

            CategoryRepository = cateogryRepository;
            ServiceModalRepository = serviceModalRepository;
            ServicePolicyRepository = servicePolicyRepository;
            ServicePolicyItemRepository = servicePolicyItemRepository;
            DiscountRepository = discountRepository;
            AvailableServiceRepository = availableServiceRepository;
            AvailableServiceTimeRepository = availableServiceTimeRepository;
            LocationRepository = locationRepository;
            TemporaryReservationRepository = temporaryReservationRepository;
            RateRepository = rateRepository;
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task Rollback()
        {
            //  Dispose();
            return Task.CompletedTask;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }
    }
}
