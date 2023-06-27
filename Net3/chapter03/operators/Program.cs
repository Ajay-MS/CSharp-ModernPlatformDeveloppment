using static System.Console;
using static System.Convert;
using System.IO;
using System.Collections;

namespace Test {
    public class Test { 
        
        public static void Main(string[] args)
        {
            WriteLine("In Chapter 3");
            ValidateParse();
        }

        public static void ValidateParse() {
            WriteLine("Before parsing");

            WriteLine("What is your age?");
            String input = ReadLine();

            try
            {
                int age = int.Parse(input);
                WriteLine($"You are {age} years old");
            }
            catch (FormatException ex)
            {
                WriteLine("The age you entered is not a valid number format.");
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType} says {ex.Message}");
            }
        }

        public static void ValidateTryParse() {
            WriteLine("How many eggs are there?");

            int count = 0;
            String input = ReadLine();
            if (int.TryParse(input, out count))
            {
                Console.WriteLine($"There are {count} eggs");
            }
            else 
            {
                WriteLine("I am failed to parse the input");    
            }
        }

        public static void ValidateConversion()
        {
            double g = 9.8;
            int h = ToInt32(g);
            Console.WriteLine($"g is {g } and h is {h }");
        }

        public static void ValidateForeachInternal() {
            string[] names = { "ajay", "ekansh", "usha", "priya" };
            IEnumerator enumerator = names.GetEnumerator();

            while (enumerator.MoveNext())
            {
                string name = (string)enumerator.Current;
                WriteLine($"{name} has {name.Length} characters");
            }

        }

        public static void ValidateForeach()
        {
            string[] names = { "ajay", "ekansh", "usha", "priya" };

            foreach (string name in names) {
                WriteLine($"{name} has {name.Length} characters.");
            }
        }

        public static void ValidateIterations() {
            string password = string.Empty;

            do
            {
                WriteLine("Enter your password");
                password = ReadLine();
            } while (password != "ajay");
        }

        public static void ValidatePatternMatching() {
            string path = @"C:\Code\Chapter3";

            Stream s = File.Open(Path.Combine(path, "file.txt"), FileMode.OpenOrCreate);

            string message = string.Empty;

            switch (s) {
                case FileStream writeableFile when s.CanWrite:
                    message = "The stream is a file that I can write to";
                    break;
                case FileStream readOnlyFile:
                    message = "The stream is read only";
                    break;
                case MemoryStream ms:
                    message = "The stream is a memroy address.";
                    break;
                default:
                    message = "The stream is some other type.";
                    break;
                case null:
                    message = "The stream is null";
                    break;
            }

            WriteLine(message);
        }

        public static void ValidateConditions() {
            bool a = true;
            bool b = false;

            WriteLine($" a & DoStuff() = {a & DoStuff()}");
            WriteLine($" b & DoStuff() = {b & DoStuff()}");
        }

        public static bool DoStuff() {
            WriteLine("I am doing some stufff");
            return true; 
        }

    }
}