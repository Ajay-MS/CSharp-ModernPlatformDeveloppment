using static System.Console;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Packt.Shared
{ 
    public class Program
    {
        public static readonly string DataFileContent = "DataFileContent";

        public static readonly string DataFileName = "DataFileName";

        public static void Main(string[] args)
        {
            CultureInfo globalization = CultureInfo.CurrentCulture;
            CultureInfo localization = CultureInfo.CurrentUICulture;

            WriteLine($"The current global culture is: {globalization.Name} and {globalization.DisplayName}");
            WriteLine($"The current global culture is: {localization.Name} and {localization.DisplayName}");

            WriteLine("en-US: English (United States)");
            WriteLine("da-DK: Danish (Denmark)");
            WriteLine("fr-CA: French (Canada)");

            WriteLine("Enter a ISO  culture code");

            string newCulture = ReadLine();
            if (!string.IsNullOrEmpty( newCulture) ) 
            {
                var ci = new CultureInfo( newCulture );
                CultureInfo.CurrentCulture = ci;
                CultureInfo.CurrentUICulture = ci;
            }
            WriteLine();

            string variable = string.Empty;

            


        }
    }
}