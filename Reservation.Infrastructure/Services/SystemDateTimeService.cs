using ReservationProject.Application.Interfaces.Shared;
using System;

namespace ReservationProject.Infrastructure.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}