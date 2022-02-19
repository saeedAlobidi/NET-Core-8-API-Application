using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Application.Interfaces.Shared
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
