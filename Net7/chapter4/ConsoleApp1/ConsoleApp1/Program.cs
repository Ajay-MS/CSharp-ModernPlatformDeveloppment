using static System.Console;

TimeTable(8, 10);

decimal taxPaid = CalculateTax(amount: 149.0M, "FR");
WriteLine($"You have paid {taxPaid} as tax");


// Converting a cardinal number to ordinal 
string ordinalNumber = CardinalToOrdinal(43);
WriteLine($"Ordinal number is {ordinalNumber}");

RunFactorial();

RunFibImperative();
RunFibFunctional();