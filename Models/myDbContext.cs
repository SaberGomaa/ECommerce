    using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class myDbContext : DbContext
    {
        public DbSet<customer> customers { get; set; }
        public DbSet<admin> admins { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<contact> contacts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data source = SABER;Initial catalog = ECommerceProject;Integrated security = true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
