using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    public class Person : IComparable<Person>
    {
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> children = new List<Person>();

        // Add delegate field 
        public EventHandler Shout;

        // data field
        public int AngerLevel;

        // Poke Method 
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                /*if (Shout != null)
                {
                    Shout(this, EventArgs.Empty);
                }*/

                Shout?.Invoke(this, EventArgs.Empty);
            }
        }

        // Methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on the date :{DateOfBirth: dddd}");
        }

        public static Person Procreate(Person p1, Person p2) {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}",
            };

            p1.children.Add( baby );
            p2.children.Add( baby );

            return baby;
        }

        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        public int CompareTo(Person? other)
        {
            return Name.CompareTo(other?.Name);
        }

        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }
    }
}
