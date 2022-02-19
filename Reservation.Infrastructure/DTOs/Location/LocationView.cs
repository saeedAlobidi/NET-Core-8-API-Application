using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.DTOs.Location
{
    public class LocationView
    {
        public long id { get; set; } 
        public long serviceId { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
    }
}
