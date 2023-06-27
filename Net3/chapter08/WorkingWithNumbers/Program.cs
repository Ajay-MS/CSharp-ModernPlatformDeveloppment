using System.Numerics;
using System.Text.RegularExpressions;
using static System.Console;

namespace Packt.Shared
{
    public class Program
    {


        public static void Main(string[] args)
        {
            ListWorking();
        }

        public static void ListWorking()
        { 
            var cities = new List<string>();
            cities.Add("Delhi");
            cities.Add("Paris");
            cities.Add("Milan");

            WriteLine("Initial list");
            foreach (string city in cities) 
            {
                WriteLine($" {city}");
            }
            WriteLine($"First city is {cities[0]}");
            WriteLine($"Last city is {cities[cities.Count - 1]}");

            cities.Insert(0, "London");
            WriteLine("After inserting");
            foreach (string city in cities)
            {
                WriteLine($" {city}");
            }

            cities.RemoveAt(1);
            WriteLine("After removing");
            foreach (string city in cities)
            {
                WriteLine($" {city}");
            }
        }

        public static void RegexValidate()
        {
            Console.Write("Enter you age: ");
            string input = ReadLine();

            var ageChecker = new Regex(@"\d");

            if (ageChecker.IsMatch(input))
            {
                Console.WriteLine("Thank you!");
            }
            else
            {
                WriteLine("This is not a valid input");
            }
        }

        public static void StringJoin()
        {
            string cities = "Paris, Delhi, Hyderabad, Rewari";
            string[] citiesArray = cities.Split(new char[] { ',' });

            string recombine = string.Join(" => ", citiesArray);
            Console.WriteLine(recombine);

            string fruit = "Apples";
            decimal price = 0.39M;
            DateTime when = DateTime.Now;

            Console.WriteLine($"{fruit} cost {price:C} on {when:dddd}");

            Console.WriteLine(string.Format("{0} cost {1:C}  on {2:dddd}.", fruit, price, when));
        }

        public static void StringSplit()
        {
            string cities = "Paris, Delhi, Hyderabad, Rewari";
            string[] citiesArray = cities.Split(new char[] { ',' });
            foreach(string city in citiesArray) 
            {
                Console.WriteLine(city);
            }
        }
       

        public static void GetLengthOfString()
        {
            string city = "London";
            WriteLine($"{city} is {city.Length} characters long.");
        }

        public static void GettingCharacters()
        {
            string city = "London";
            WriteLine($"{city[0]} is {city[1]} characters.");
        }


        public static void WorkingWithBigInteger()
        {
            var largest = ulong.MaxValue;
            var atomsInUniverse = BigInteger.Parse("123456789012345678901234567890");
            WriteLine($"{atomsInUniverse,40:N0}");
        }

        public static void WorkingWithComplexNumber()
        {
            var c1 = new Complex(4, 2);
            var c2 = new Complex(3, 5);
            var c3 = c1 + c2;
            WriteLine($"{c1} added to the {c2} becomes {c3}");
        }
    }
}