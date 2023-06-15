using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EczacibasiHW1.Models.Entity
{
    [Table("Books")]
    public class Book : BaseEntity<int>
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Required]
        [MaxLength(100)]
        public string Publisher { get; set; }

        public string Translator { get; set; }

        [Required]
        [MaxLength(15)]
        public string ISBN { get; set; } //International Standard Book Number

        public int Page { get; set; }

        [MaxLength(4)]
        public string FirstEditionYear { get; set; }

        public string Language { get; set; }

        [Required]
        private double _price;

        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The price must be greater than 0.");
                }

                _price = value;
            }
        }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

    }
}
