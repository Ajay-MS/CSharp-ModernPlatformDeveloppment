using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public class ThingsOfDefault
    {
        public int Population;
        public DateTime when;
        public string Name;
        public List<Person> People;

        public ThingsOfDefault() { 
            
            // old way 
            Population = default(int);
            when = default(DateTime);
            Name = default(string);
            People = default(List<Person>);

            // New way 
            Name = default;
            People = default;
            Population = default;
            when = default;
            
        }

        // Return multiple values 
        public (string Name, int Number) GetNamedFruit()
        {
            return (Name: "Apple", Number: 30);
        }
    }
}
