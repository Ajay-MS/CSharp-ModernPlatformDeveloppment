using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using static System.Console;

namespace Test {
    class Program {
        public static void Main(string[] args)
        {
            Instrumneting1();
        }

        public static void Instrumneting1() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",
                    optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var ts = new TraceSwitch(
                    displayName: "PacktSwitch",
                    description: "This swtich is set via a JSON Config"
                  );

            configuration.GetSection("PacktSwitch").Bind(ts);

            Trace.WriteLine(ts.TraceError, "Trace Error");
            Trace.WriteLine(ts.TraceWarning, "Trace Warning");
            Trace.WriteLine(ts.TraceInfo, "Trace Info");
            Trace.WriteLine(ts.TraceVerbose, "Trace Verbose");

        }

        public static void Instrumneting() {

            // Add a trace listener 
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("logs.txt")));

            Trace.AutoFlush = true;

            Debug.WriteLine("This is debug line");
            Trace.WriteLine("This is a trace line");
        }

        public static void FactorialRunner() {
            bool isNumber = false;

            WriteLine("Enter a number");
            String input = Console.ReadLine();
            isNumber = int.TryParse(input, out int number);
            if (isNumber )
            {
                WriteLine($"Factorial of {number} is {Factorial(number)}");
            }
        }

        public static int Factorial(int n) { 
            if (n == 0 || n == 1) return 1;

            return n *  Factorial(n - 1);
        }
    }
}