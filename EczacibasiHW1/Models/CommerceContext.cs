using Microsoft.EntityFrameworkCore;
using EczacibasiHW1.Models.Entity;

namespace EczacibasiHW2.Models
{
    public class CommerceContext : DbContext
    {

        public CommerceContext(DbContextOptions<CommerceContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}

