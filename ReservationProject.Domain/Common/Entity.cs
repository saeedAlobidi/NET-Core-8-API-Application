using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Domain.Common
{
    public abstract class Entity<T> : IEntity
    {
        public T Id { get; set; }
    }
}
