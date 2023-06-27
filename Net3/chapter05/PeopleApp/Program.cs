using Packt.Shared;
using static System.Console;

namespace Test { 
    public class Program
    {

        public static readonly string HomePlanet = "Earth";

        public static void Main(string[] args) {



            var bob = new Person();
            bob.Name = "Bob";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            bob.BucketList = PacktLibrary.WondersOfTheAncientWorld.LighthouseOfAlexandria | PacktLibrary.WondersOfTheAncientWorld.HangingGardensOfBabylon;
            bob.Childrens.Add(new Person { Name = "Child1"});
            bob.Childrens.Add(new Person { Name = "Child2"});

            WriteLine($"{bob.Name} was born on {bob.DateOfBirth.ToShortDateString()} and favourite wonder: {bob.BucketList}");

            foreach(Person child in bob.Childrens) 
            {
                WriteLine($"{child.Name}");
            }

            var alice = new Person() 
            {
                Name = "Alice",
                DateOfBirth = new DateTime(1965, 12, 22)
            };

            WriteLine($"{alice.Name} was born on {alice.DateOfBirth.ToShortDateString()}");


            WriteLine($"{bob.Name} has home plannet as {HomePlanet}");

            Person blankPerson = new Person();
            WriteLine($"{blankPerson.Name} was born on {blankPerson.DateOfBirth.ToShortDateString()}");

            var tod = new ThingsOfDefault();
            var result = tod.GetNamedFruit();
            WriteLine($"{result.Item1} has count {result.Item2}");

            (string fruitName, int fruitCount) = tod.GetNamedFruit();
            WriteLine($"{fruitName} has total count {fruitCount}");
        } 

        
    }
}
