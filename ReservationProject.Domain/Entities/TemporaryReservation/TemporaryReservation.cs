using ReservationProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReservationProject.Domain.Entities.TemporaryReservation
{
    public class TemporaryReservation : Entity<long>, ISoftDelete, IAuditableEntity, ICreationEntity
    {

        public string ReservationUserId { get; set; }

        [ForeignKey("serviceModal")]
        public long? serviceModalId { get; set; }

        [ForeignKey("ServicePolicy")]
        public long? ServicePolicyId { get; set; }

        public DateTime dateOfReservation { get; set; }
 
        public ServiceModal.ServiceModal serviceModal { get; set; }
        public ServicePolicy.ServicePolicy ServicePolicy { get; set; }

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
