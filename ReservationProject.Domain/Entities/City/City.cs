using ReservationProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using ReservationProject.Domain.Entities.Country;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationProject.Domain.Entities.City
{
    public class City : Entity<long>, ISoftDelete, IAuditableEntity, ICreationEntity
    {
        public string name { get; set; }

        [ForeignKey("country")]
        public long countryId { get; set; }

        public Country.Country country { get; set; }
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
