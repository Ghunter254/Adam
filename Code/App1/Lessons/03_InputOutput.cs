namespace Lessons;

class InputOutput
{
    public static void Run()
    {

        // Console.WriteLine() outputs text and moves to a new line... i.e. creates a newline after.
        Console.WriteLine("This is a line with a newline at the end.");

        // Console.Write() outputs text but stays on the same line
        Console.Write("This is on the same line... ");
        Console.Write("see? Still same line.\n"); // The \n creates a newline

        // String interpolation (cleaner way to combine variables into strings)
        // In earlier lessons we used concatenation with + ... but this is neater.
        string demoName = "Adam";
        int demoAge = 20;
        Console.WriteLine($"My name is {demoName}, and I am {demoAge} years old."); // Note the $ before the string


        // Console.ReadLine() always returns a string ... So even when asking for a number, it returns text.
        Console.Write("Enter your name: ");

        // We ask for a value from the user and store it in a variable.
        string name = Console.ReadLine();

        Console.Write("Enter your age: ");
        string ageInput = Console.ReadLine(); // This is still a string

        Console.WriteLine($"Hello {name}, you are {ageInput} years old.");

        // -----------------------------
        // TRY - CATCH - FINALLY
        // -----------------------------
        // Used for handling unexpected errors at runtime.
        // Example: converting invalid input, dividing by zero, reading missing files, etc.

        Console.Write("Enter a number to divide 100 by: ");
        string numberInput = Console.ReadLine();

        try
        {
            // int.Parse() throws an exception if the input is not a valid number
            int userNumber = int.Parse(numberInput);

            int result = 100 / userNumber; // Will throw if userNumber == 0

            Console.WriteLine($"100 / {userNumber} = {result}");
        }
        catch (FormatException)
        {
            // Happens if the user types something not convertable to a number
            Console.WriteLine("Error: That is not a valid number. Please enter digits only.");
        }
        catch (DivideByZeroException)
        {
            // Happens if the user types 0
            Console.WriteLine("Error: You cannot divide by zero.");
        }
        catch (Exception ex)
        {
            // Catches any other unexpected error
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
        finally
        {
            // This runs ALWAYS, no matter what happened above
            Console.WriteLine("End of calculation (finally block executed).");
        }

    }
}
