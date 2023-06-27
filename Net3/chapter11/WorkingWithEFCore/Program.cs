using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Linq;
using static System.Console;

namespace Packt.Shared
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isSaved = AddProduct(1, "Mazza", 70);
            WriteLine($"{isSaved}");
        }

        public static bool AddProduct(int categoryID, string productName, decimal? price)
        {
            using (var db = new Northwind())
            {
                var newProduct = new Product
                {
                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price,
                };

                db.Products.Add(newProduct);

                int affected = db.SaveChanges();
                return affected == 1;
            }
        }

        public static void QueryWithLike()
        {
            using (var db = new Northwind())
            { 
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine($"Enter part of a product name");
                string input = ReadLine();

                IQueryable<Product> products = db.Products.Where(p => p.ProductName.Contains(input));

                foreach (var product in products)
                {
                    WriteLine($"{product.ProductID}, {product.ProductName}, {product.Cost}");
                }
            }
        }

        public static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                var loggerFactorey = db.GetService<ILoggerFactory>();
                loggerFactorey.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Products that cost more than a price, highest at top.");

                string input;
                decimal price;

                do
                {
                    Write("Enter a product price");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));

                IQueryable<Product> products = db.Products
                    .Where(product => product.Cost > price);

                foreach (Product product in products)
                {
                    WriteLine($"{product.ProductID}, {product.ProductName}, {product.Cost}");
                }
            }
        }

        public static void QueryCategories()
        {
            using (var db = new Northwind())
            {
                db.Database.EnsureCreated();

                WriteLine("Categories and how many products they have");

                // Query to get all the categories and their related products
                List<Category> cats = db.Categories.ToList();

                foreach (Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count}");
                }
            }

        }
    }
}