using ReservationProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReservationProject.Domain.Entities.Address
{
    public class Address : Entity<long>, ISoftDelete, IAuditableEntity, ICreationEntity
    {

        public string info { get; set; }
        public string userId { get; set; }

        [ForeignKey("City")]
        public long cityId { get; set; }
        public City.City City { get; set; }

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
