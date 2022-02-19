using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.DTOs.AvailableServiceTime
{
    public class AvailableServiceTimeView
    {
        public long id { get; set; }
        public string day { get; set; }
        public string fromTime { get; set; }
        public string toTime { get; set; }
          
        public long availableServiceId { get; set; }
    }
}
