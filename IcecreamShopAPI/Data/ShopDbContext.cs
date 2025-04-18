using Microsoft.EntityFrameworkCore;
using IcecreamShopAPI.Models;
using Namotion.Reflection;

namespace IcecreamShopAPI.Data {
    public class ShopDbContext: DbContext {
        public ShopDbContext(DbContextOptions options): base(options) {}

        public DbSet<Icecream> Icecreams{get; set;}
        public DbSet<Cashier> Cashiers {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Transaction> Transactions {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the Many-to-Many Relationships
            modelBuilder.Entity<Icecream>().HasMany(e => e.Customers).WithMany(e => e.IcecreamHistory);
            modelBuilder.Entity<Transaction>().HasMany(e => e.Icecreams).WithMany(e => e.Transactions);
            // Add pre-filled data
            modelBuilder.Entity<Icecream>().HasData(
                new Icecream {
                    Id = 1,
                    Scoops = 2,
                    Flavors = ["Blueberry", "Strawberry"],
                    OnCone = true,
                    Toppings = ["Cherry"],
                    Size = Size.Medium,
                    Customers = [],
                    Transactions = []
                },
                new Icecream {
                    Id = 2,
                    Scoops = 1,
                    Flavors = ["Mint Chocolate"],
                    Toppings = ["Sprinkles", "Chocolate Chips"],
                    OnCone = false,
                    Size = Size.Large,
                    Customers = [],
                    Transactions = []
                }
            );

            modelBuilder.Entity<Cashier>().HasData(
                new Cashier {
                    Name = "John Pickleberry",
                    PhoneNumber = "305-123-4567",
                    TransactionHistory = []
                },
                new Cashier {
                    Name = "Jessica Largecake",
                    PhoneNumber = "305-533-6103",
                    TransactionHistory = []
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer {
                    Name = "Lucas Rodriguez",
                    Email = "coldcoder9225@proton.me",
                    IcecreamHistory = [],
                    TransactionHistory = []
                },
                new Customer {
                    Name = "M Andy",
                    Email = "mail@potatoes.vore",
                    IcecreamHistory = [],
                    TransactionHistory = []
                }
            );
        }
    }
}