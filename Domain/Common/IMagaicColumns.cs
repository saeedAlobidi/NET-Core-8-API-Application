using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Customer
{
    public interface IMagaicColumns
    {
        bool isDeleted { get; set; }
        public DateTime deleteddAt { get; set; }
        public int  deletedBy { get; set; }
        public DateTime modifiedAt { get; set; }
        public int modifiedBy { get; set; }
    }
}
