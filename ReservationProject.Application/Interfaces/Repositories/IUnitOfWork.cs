using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationProject.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IServiceModalRepository ServiceModalRepository { get; }

        IServicePolicyRepository ServicePolicyRepository { get; }
        IServicePolicyItemRepository ServicePolicyItemRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        IAvailableServiceRepository AvailableServiceRepository { get; }
        IAvailableServiceTimeRepository AvailableServiceTimeRepository { get; }
        ILocationRepository LocationRepository { get; }
        ITemporaryReservationRepository TemporaryReservationRepository { get; }
        IRateRepository RateRepository { get; }


        Task<int> Commit(CancellationToken cancellationToken);

        Task Rollback();
    }
}
