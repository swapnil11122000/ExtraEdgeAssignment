using ExtraEdge.Models;
using Microsoft.EntityFrameworkCore;
namespace ExtraEdge.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Brand> brands { get; set; }
        public DbSet<Customer> customers { get;set; }
        public DbSet<Mobile> mobiles { get; set; }
        public DbSet<Purchase> purchases { get; set; }

       
    }
}
