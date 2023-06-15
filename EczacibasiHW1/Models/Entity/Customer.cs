using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EczacibasiHW1.Models.Entity
{
    [Table("Customers")]
    public class Customer : BaseEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [Required]
        [MaxLength(11)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

    }
}
