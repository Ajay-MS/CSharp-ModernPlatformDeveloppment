using System.Linq;
using System.Reflection;
using System;
using static System.Console;


namespace Test {
    class Test {
        public static void Main() {
            TestUserInput();
        }   

        public static void TestUserInput() {
            Write("Press any key combination");
            ConsoleKeyInfo keyInfo = ReadKey();
            WriteLine();
            WriteLine($"Key : {keyInfo.Key}, Char: {keyInfo.KeyChar}, Modifier: {keyInfo.Modifiers}");
        }

        public static void TestImport() {
            WriteLine("Hello World");
        }

        public static void PrintLibs() {
            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Hello, Welcome to Chapter 2!");

            foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies()) {
                var a = Assembly.Load(new AssemblyName(r.FullName));

                int methodCount = 0;

                foreach (var t in a.DefinedTypes) {
                    methodCount += t.GetMethods().Count();
                }

                Console.WriteLine("{0} types with {1} methods in {2} assembly.", 
                    a.DefinedTypes.Count(),
                    methodCount,
                    r.Name );
            }
        }
    }
}
