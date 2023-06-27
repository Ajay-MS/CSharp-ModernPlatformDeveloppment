

using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
    public class Northwind: DbContext
    { 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set;}

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }  

        public Northwind(DbContextOptions<Northwind> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // Define one to many relation 
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryID);

            modelBuilder.Entity<Customer>()
                 .Property(c => c.CustomerID)
                 .IsRequired()
                 .HasMaxLength(5);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CompnayName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Customer>()
                .Property(c => c.ContactName)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Country)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerID);

            modelBuilder.Entity<Employee>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Employee>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Employee>()
               .Property(c => c.Country)
               .IsRequired()
               .HasMaxLength(15);

            modelBuilder.Entity<Employee>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Employee);

            modelBuilder.Entity<Employee>()
                .HasKey(c => c.EmployeeID);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products);

            modelBuilder.Entity<Product>()
            .HasKey(c => c.ProductID);

            modelBuilder.Entity<Order>()
               .HasOne(p => p.Shipper)
               .WithMany(s => s.orders)
               .HasForeignKey(o => o.ShipVia);

            modelBuilder.Entity<Order>()
            .HasKey(c => c.OrderID);

            modelBuilder.Entity<OrderDetail>()
                .ToTable("Order Details");

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.orderID, od.ProductID });


            modelBuilder.Entity<Supplier>()
                .HasKey(s => s.SupplierID);

            modelBuilder.Entity<Supplier>()
                .Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Supplier);
        }
    }
}