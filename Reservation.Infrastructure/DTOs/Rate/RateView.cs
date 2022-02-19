using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.DTOs
{
    public class RateView
    {
        public int rate { get; set; }
        public string comment { get; set; } 
        public long serviceModalId { get; set; }
    }
}
