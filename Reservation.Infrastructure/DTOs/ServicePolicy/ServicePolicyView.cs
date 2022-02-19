using ReservationProject.Infrastructure.DTOs.ServicePolicyItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.DTOs.ServicePolicy
{
    public class ServicePolicyView
    {
        public long id { get; set; }
        public int version { get; set; } 
        public long? serviceId { get; set; }
        public IEnumerable<ServicePolicyItemView> items { get; set; }
    }
}
