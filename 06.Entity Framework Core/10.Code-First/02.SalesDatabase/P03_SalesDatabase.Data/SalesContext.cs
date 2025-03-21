using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Common;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
            
        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {

        }

        // DbSets here
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API here
            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasDefaultValue(ValidationConstants.Product.DefaultProductDescription);

            modelBuilder.Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql(ValidationConstants.Sale.DefaultDateValue);

            // Seeding data in database
            modelBuilder.Entity<Customer>()
                .HasData(
                    new Customer { CustomerId = 1, Name = "Ivan Petrov", Email = "ivan@example.com", CreditCardNumber = "1234567890123456" },
                    new Customer { CustomerId = 2, Name = "Maria Ivanova", Email = "maria@example.com", CreditCardNumber = "9876543210987654" },
                    new Customer { CustomerId = 3, Name = "Georgi Dimitrov", Email = "georgi@example.com", CreditCardNumber = "4567891234567890" },
                    new Customer { CustomerId = 4, Name = "Elena Todorova", Email = "elena@example.com", CreditCardNumber = "1122334455667788" },
                    new Customer { CustomerId = 5, Name = "Petar Vasilev", Email = "petar@example.com", CreditCardNumber = "6677889900112233" }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { ProductId = 1, Name = "Laptop", Quantity = 5, Price = 1200.99m },
                    new Product { ProductId = 2, Name = "Mouse", Quantity = 15, Price = 25.50m },
                    new Product { ProductId = 3, Name = "Keyboard", Quantity = 10, Price = 45.99m },
                    new Product { ProductId = 4, Name = "Monitor", Quantity = 7, Price = 200.00m },
                    new Product { ProductId = 5, Name = "Headphones", Quantity = 20, Price = 75.80m }
                );

            modelBuilder.Entity<Store>()
                .HasData(
                    new Store { StoreId = 1, Name = "Tech Store Sofia" },
                    new Store { StoreId = 2, Name = "ElectroMart Plovdiv" },
                    new Store { StoreId = 3, Name = "Gadget House Varna" },
                    new Store { StoreId = 4, Name = "Best Buy Burgas" },
                    new Store { StoreId = 5, Name = "Digital World Ruse" }
                );

            modelBuilder.Entity<Sale>()
                .HasData(
                    new Sale { SaleId = 1, ProductId = 1, CustomerId = 2, StoreId = 3 },
                    new Sale { SaleId = 2, ProductId = 3, CustomerId = 1, StoreId = 2 },
                    new Sale { SaleId = 3, ProductId = 2, CustomerId = 5, StoreId = 4 },
                    new Sale { SaleId = 4, ProductId = 4, CustomerId = 3, StoreId = 1 },
                    new Sale { SaleId = 5, ProductId = 5, CustomerId = 4, StoreId = 5 }
                );
        }
    }
}
