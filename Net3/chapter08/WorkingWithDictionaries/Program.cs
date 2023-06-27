using static System.Console;
using System.Collections.Generic;

namespace Packt.Shared
{
    public class Program
    { 
        public static void Main(string[] args) 
        {
            var keywords = new Dictionary<string, string>();
            keywords.Add("int", "32 bit interger");
            keywords.Add("long", "64 bit interger");
            keywords.Add("float", "decimal point");

            WriteLine("Keywords and their definitions");
            foreach(KeyValuePair<string, string> kvp in keywords) 
            {
                WriteLine($" {kvp.Key} : {kvp.Value}");
            }

            WriteLine($"Definition of long is {keywords["long"]}");
        }
    }
}