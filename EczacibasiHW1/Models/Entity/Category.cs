using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EczacibasiHW1.Models.Entity
{
    [Table("Categories")]
    public class Category : BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
        public List<Book> BookList { get; set; }
    }

}
