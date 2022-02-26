using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Customer
{

    [Table("Customer", Schema = "dbo")]
    public  class Customer : Identifier<long>, IMagaicColumns
    {


        public string name { get; set; }
        public string age { get; set; }
        

        public virtual bool isDeleted { get; set; }
        public virtual DateTime deleteddAt { get; set; }
        public virtual int deletedBy { get; set; }
        public virtual DateTime modifiedAt { get; set; }
        public virtual int modifiedBy { get; set; }
    }
}
