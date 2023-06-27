using System.Reflection;

PrintDefaultValues();

static void PrintDefaultValues()
{
    Console.WriteLine($"default(int) = {default(int)}");
    Console.WriteLine($"default(bool) = {default(bool)}");
    Console.WriteLine($"default(DateTime) = {default(DateTime)}");
    Console.WriteLine($"default(string) = {default(string)}");
}

static void TestVariables()
{
    double weightOfPerson = 10.1;

    Console.WriteLine($"The variable {nameof(weightOfPerson)} has value {weightOfPerson}");
}

static void PrintAssemblyDetails()
{
    Assembly? myApp = Assembly.GetEntryAssembly();

    if (myApp == null) return;

    foreach (AssemblyName assemblyName in myApp.GetReferencedAssemblies())
    {
        Assembly a = Assembly.Load(assemblyName);

        int methodCount = 0;

        foreach (TypeInfo typeInfo in a.GetTypes())
        {
            methodCount += typeInfo.GetMethods().Count();
        }

        Console.WriteLine($"{a.DefinedTypes.Count()} types with {methodCount} methods in {assemblyName.Name} assembly");
    }

}



