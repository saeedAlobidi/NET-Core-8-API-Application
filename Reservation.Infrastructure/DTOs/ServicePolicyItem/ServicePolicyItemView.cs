using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.DTOs.ServicePolicyItem
{
    public class ServicePolicyItemView
    {
        public long id { get; set; }
        public string item { get; set; } 
        public long? servicePolicyId { get; set; }
    }
}
