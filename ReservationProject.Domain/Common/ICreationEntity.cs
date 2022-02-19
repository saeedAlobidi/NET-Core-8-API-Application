using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Domain.Common
{
    public interface ICreationEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }
}
