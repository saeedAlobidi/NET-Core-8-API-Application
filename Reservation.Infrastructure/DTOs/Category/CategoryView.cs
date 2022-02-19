using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.DTOs.Cateogry
{
    public class CategoryView
    {
        public long id { get; set; }
        public string name { get; set; }
        public long cateogryId { get; set; }
    }
}
