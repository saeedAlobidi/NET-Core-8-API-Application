using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Customer
{
    public abstract class Identifier<T> : IEntity
    {

        [Key]
        public T Id { get; set; }
    }
}
