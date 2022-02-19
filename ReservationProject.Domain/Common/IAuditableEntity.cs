using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Domain.Common
{
    public interface IAuditableEntity
    {
        string LastModifiedBy { get; set; }
        DateTime? LastModifiedOn { get; set; }
    }
}
