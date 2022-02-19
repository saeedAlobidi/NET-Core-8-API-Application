using ReservationProject.Domain.Common;
using ReservationProject.Domain.Entities.Cateogry;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReservationProject.Domain.Entities.CategoryProperties
{
    public class CategoryProperties : Entity<long>, ISoftDelete, IAuditableEntity, ICreationEntity
    {
        public string name { get; set; }

        [ForeignKey("category")]
        public long? categoryId { get; set; }
        public Category category { get; set; } 
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
