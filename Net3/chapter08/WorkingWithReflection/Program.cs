using System.Reflection;
using static System.Console;

namespace Packt.Shared
{
    public class Program
    { 
        public static void Main(string[] args) 
        {
            WriteLine("Assembly metadata.");

            Assembly assembly = Assembly.GetEntryAssembly();
            WriteLine($"FullName : {assembly.FullName}");
            WriteLine($"Location : {assembly.Location}");

            var attributes = assembly.GetCustomAttributes(true);
            WriteLine("Attributes");
            foreach( var attribute in attributes)
            {
                WriteLine($" {attribute.GetType()}");
            }
        }
    }
}