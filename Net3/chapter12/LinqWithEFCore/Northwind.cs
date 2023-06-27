using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public class Northwind: DbContext
    {
          public DbSet<Category> categories { get; set; }

          public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");

            optionsBuilder.UseSqlite($"Data Source={path}");
        }
    }
}
