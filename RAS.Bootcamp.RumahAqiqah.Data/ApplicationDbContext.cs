using RAS.Bootcamp.RumahAqiqah.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace RAS.Bootcamp.RumahAqiqah.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Account> Accounts {get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDelivery> OrderDeliveries { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHistory> orderHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Promo> Promos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsedPromo> UsedPromos { get; set; }
        public DbSet<UsedReferal> UsedReferals { get; set; }
        public DbSet<UserOrderChild> UserOrderChildren { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

    }
}
