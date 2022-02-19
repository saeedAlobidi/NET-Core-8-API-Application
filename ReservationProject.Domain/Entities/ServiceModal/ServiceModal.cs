using ReservationProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Domain.Entities.ServiceModal
{
    public class ServiceModal : Entity<long>, ISoftDelete, IAuditableEntity, ICreationEntity
    {
         
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int countAllowReserve { get; set; }
        public bool isLock { get; set; } = false;
        public bool hasDiscount { get; set; } = false;

        // [ForeignKey("serviceProvider")]
        public string serviceProviderId { get; set; }
        // public ServiceProvider.ServiceProvider serviceProvider { get; set; }
 
        // ICreationEntity
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        
        // IAuditableEntity
        public virtual string LastModifiedBy { get; set; }
        public virtual DateTime? LastModifiedOn { get; set; }

        // ISoftDelete
        public virtual bool Is_Deleted { get; set; }
        public virtual DateTime deleteTime { get; set; }
        public virtual string UserId { get; set; }
    }
}
