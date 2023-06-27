using Packt.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacktLibrary
{
    public class PersonComparator : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);

            if (result != 0)
            {
                return result;
            }

            return x.Name.CompareTo(y.Name);
        }
    }
}
