using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.DTOs.TemporaryReservation
{
    public class TemporaryReservationView
    {
        public long id { get; set; }
        public string ReservationUserId { get; set; } 
        public long? serviceModalId { get; set; } 
        public long? ServicePolicyId { get; set; } 
        public DateTime dateOfReservation { get; set; }
    }
}
