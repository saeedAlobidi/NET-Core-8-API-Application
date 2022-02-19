using ReservationProject.Domain.Common;
using ReservationProject.Domain.Entities.ServiceModal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReservationProject.Domain.Entities.Discount
{
    public class Discount : Entity<long>, ISoftDelete, IAuditableEntity, ICreationEntity
    {
        public Discount() { }
        public int discount { get; set; }

        [ForeignKey("serviceModal")]
        public long serviceModalId { get; set; }
        public ServiceModal.ServiceModal serviceModal { get; set; }

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
