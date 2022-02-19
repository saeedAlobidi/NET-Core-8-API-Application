using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.DTOs.Discount
{
    public class DiscountView
    {
        public long id { get; set; }
        public int discount { get; set; }
        public long serviceModalId { get; set; }

    }
}
