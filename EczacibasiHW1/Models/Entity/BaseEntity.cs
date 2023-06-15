using System;
using System.ComponentModel.DataAnnotations;

namespace EczacibasiHW1.Models.Entity
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
