using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Packt.Shared
{
    // this manages the connection to the database 
    class Northwind : DbContext
    {
        // these properties map to the table in the database 
        public DbSet<Category> Categories { get; set;  }
        public DbSet<Product> Products { get; set;  }

        public string DbPath { get; set; }

        public Northwind() {
            var path = Environment.CurrentDirectory;
            // "C:\\coderepos\\learnCSharp\\chapter11\\WorkingWithEFCore"
            DbPath = System.IO.Path.Join(path, "Northwind.db");
            WriteLine(DbPath);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
