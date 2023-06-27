using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public partial class Person
    {
        public string Origin
        {
            get
            {
                return $"{Name} was born on  {DateOfBirth.ToShortDateString()}";
            }
        
        }

        public string Greeting => $"{Name} says 'Hello!";

        public Person this[int index]
        { 
            get { return Childrens[index]; }
            set { Childrens[index] = value; }
        }
    }
}
