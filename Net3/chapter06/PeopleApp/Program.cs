using Packt.Shared;
using PacktLibrary;
using static System.Console;

namespace Test
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            var harry = new Person { Name = "Harry" };
            var mary = new Person { Name = "Mary" };
            var jill = new Person { Name = "Jill" };

            // create baby 1 
            var baby1 = mary.ProcreateWith(harry);

            // create baby 2 
            var baby2 = Person.Procreate(harry, jill);

            // create baby3
            var baby3 = harry * mary;

            WriteLine($"{harry.Name} has {harry.children.Count} children.");
            WriteLine($"{mary.Name} has {mary.children.Count} children.");
            WriteLine($"{jill.Name} has {jill.children.Count} children.");

            WriteLine($"Factorial of 5 is {Factorial(5)}");

            harry.Shout = Hary_Shout;
            harry.Poke();
            harry.Poke();
            harry.Poke();
            harry.Poke();

            Person[] people =
            {
                new Person {Name = "Ajay"},
                new Person {Name = "Ekansh"},
                new Person {Name = "Usha"},
                new Person {Name = "Priya"},
            };

            WriteLine("Initial list of people.");
            foreach (var person in people) 
            {
                WriteLine($" {person.Name} ");
            }

            WriteLine("Use persons IComparable to sort the person");
            Array.Sort(people, new PersonComparator());
            foreach (var person in people)
            {
                WriteLine($" {person.Name} ");
            }
        }

        public static int Factorial(int number) {
            if (number < 0) {
                throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
            }
            return localFactorial(number);

            int localFactorial(int localNumber)
            {
                if (localNumber < 1) { return 1;  }
                return localNumber * localFactorial(localNumber - 1);
            }
        }

        public static void Hary_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is the angry: {p.AngerLevel}");
        }
    }
}

