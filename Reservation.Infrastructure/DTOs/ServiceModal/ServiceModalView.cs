using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.DTOs.ServiceModal
{
    public class ServiceModalView
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int countAllowReserve { get; set; }
        public bool isLock { get; set; } = false;
        public bool hasDiscount { get; set; } = false;
         
        public string serviceProviderId { get; set; }
    }
}
