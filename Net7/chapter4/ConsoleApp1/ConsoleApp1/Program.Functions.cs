partial class Program
{
    static void TimeTable(int number, int size)
    {
        Console.WriteLine("Printing table");
        for (int i = 1; i <= size; i++)
        {
            Console.WriteLine($" {number} * {i} = {number * i} ");
        }
        WriteLine();
    }

    static decimal CalculateTax(decimal amount, string regionCode)
    {
        decimal rate = 0.0M;
        switch(regionCode)
        {
            case "CH":
                rate = 0.08M;
                break;
            case "DK":
            case "NO":
                rate = 0.25M;
                break;
            case "GB":
            case "FR":
                rate = 0.2M;
                break;
            default:
                rate = 0.06M;
                break;
        }

        return rate * amount;
    }

    /// <summary>
    /// Pass a 32-bit integer and it will be converted into its ordinal equivalent
    /// </summary>
    /// <param name="number">Number as the cardinal form e.g. 1, 2, 3, 4 and so on. </param>
    /// <returns>Number a ordinal form e.g. 1st, 2nd, 3rd, 4th and so on.</returns>
    static string CardinalToOrdinal(int number)
    {
        int lastTwoDigits = number % 100;
        switch (lastTwoDigits) {
            case 11:
            case 12:
            case 13:
                return $"{number}th";
            default:
                int lastDigit = number % 10;
                string suffix = lastDigit switch
                {
                    1 => "st",
                    2 => "nd",
                    3 => "rd",
                    _ => "th",
                };
                return $"{number}{suffix}";
        }
    }


    static int Factorial(int number)
    {
        // Invalid case
        if (number < 0)
        {
            throw new ArgumentException($"Factorial is invalid for negative numbers. {nameof(number)}: {number}");
        }

        // Base case 
        if (number == 0 || number == 1)
            return 1;

        checked
        {
            return number * Factorial(number - 1);
        }
    }

    static void RunFactorial()
    { 
        for(int i = 1; i <= 15; i++)
        {
            try
            {
                WriteLine($"Factorial of {i} : {Factorial(i)}");
            }
            catch (OverflowException)
            {
                WriteLine($"{i}! is too big for 32 bit integer");
            } catch (Exception e)
            {
                WriteLine($"{i}! throws {e.GetType()} : {e.Message}");
            }
            
        }
        WriteLine();
    }

    static int FibImperative(int number)
    {
        if (number == 0 || number == 1)
            return number;
        return FibImperative(number - 1) + FibImperative(number - 2);
    }

    static void RunFibImperative()
    {
        for(int i = 1; i <= 30; i++)
        {
            WriteLine($"Fibonacci of {i} : {FibImperative(i)}");
        }
    }

    static int FibFunctional(int number)
    {
        return number switch
        {
            0 => 0,
            1 => 1,
            _ => FibFunctional(number - 1) + FibFunctional(number - 2),
        };
    }

    static void RunFibFunctional()
    {
        for (int i = 1; i <= 30; i++)
        {
            WriteLine($"Fibonacci of {i} : {FibFunctional(i)}");
        }
    }
}