using System.Linq;
using static System.Console;

namespace Packt.Shared
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var names = new string[] { "Ajay", "Ekansh", "Priya", "Usha" };

            //LinqWithSorting(names);

            LinqWithSets();
        }

        public static void LinqWithSets()
        {
            var cohort1 = new string[] { "Rachel", "Gareth", "Jonathan", "George" };
            var cohort2 = new string[] { "Jack", "Stephen", "Daniel", "Jack", "Jared" };
            var cohort3 = new string[] { "Declan", "Jack", "Jack", "Jasmine", "Conor" };

            Output(cohort1, "Cohort1");
            Output(cohort2, "Cohort2");
            Output(cohort3, "Cohort3");
        }

        public static void Output(IEnumerable<string> cohort, string description = "")
        { 
            if (!string.IsNullOrEmpty(description))
            {
                WriteLine(description);
            }
            Write("  ");
            WriteLine(string.Join(", ", cohort.ToArray()));
        }

        public static void LinqWithArrayOfExceptions()
        {
            var errors = new Exception[]
            {
                new ArgumentException(),
                new SystemException(),
                new IndexOutOfRangeException(),
                new InvalidOperationException(),
                new NullReferenceException(),
                new InvalidCastException(),
                new OverflowException(),
                new DivideByZeroException(),
                new ApplicationException(),
            };

            var numberErrors = errors.OfType<ArgumentException>();

            foreach ( var error in numberErrors )
            {
                WriteLine( error );
            }
        }

        public static void LinqWithSorting(string[] names)
        {
            var query = names
                .Where(name => name.Length > 4)
                .OrderBy(name => name.Length)
                .ThenBy(name => name);

            foreach (string item in query)
            {
                WriteLine(item);
            }
        }

        public static void LinqWithArrayOfStrings()
        {
            var names = new string[] { "Ajay", "Ekansh", "Priya", "Usha" };

            //var query = names.Where(new Func<string, bool>(NameLongerThanFour));

            //var query = names.Where(NameLongerThanFour);

            var query = names.Where(name => name.Length > 4);

            foreach(string item in query)
            {
                WriteLine(item);
            }

        }


        public static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }
    }
    

}