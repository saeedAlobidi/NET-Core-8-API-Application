using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationProject.Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        IDbConnection Connection { get; }
        bool HasChanges { get; }
        EntityEntry Entry(object entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
