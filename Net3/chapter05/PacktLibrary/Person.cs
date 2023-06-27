using PacktLibrary;
using System.Collections.Generic;

namespace Packt.Shared {
    public partial class Person : Object
    {
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Childrens = new List<Person>();

        public Person() {
            Name = "Unknown";
            DateOfBirth = DateTime.Now;
        }

    }
}