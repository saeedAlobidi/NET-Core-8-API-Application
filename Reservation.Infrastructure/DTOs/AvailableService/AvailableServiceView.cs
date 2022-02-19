using ReservationProject.Infrastructure.DTOs.AvailableServiceTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.DTOs.AvailableService
{
    public class AvailableServiceView
    {
        public long id { get; set; }
        public bool everyWeek { get; set; }
        public long ServiceModalId { get; set; }
        public IEnumerable<AvailableServiceTimeView> AvailableServiceTimeList { get; set; }
    }
}
    