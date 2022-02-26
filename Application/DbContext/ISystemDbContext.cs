using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.DbContext
{
   public interface ISystemDbContext
    {
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
