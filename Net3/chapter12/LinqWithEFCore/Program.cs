using static System.Console;

namespace Packt.Shared
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            FilterAndSort();
        }

        public static void FilterAndSort()
        {
            using (var db = new Northwind())
            {
                var query = db.products
                    .Where(product => product.UnitPrice < 10M);
                    //.OrderByDescending(product => product.UnitPrice);

                WriteLine($"Products that costs less than $10");
                foreach(var item in query)
                {
                    WriteLine($"{item.ProductID} {item.ProductName}");
                }
            }
        }
    }
}