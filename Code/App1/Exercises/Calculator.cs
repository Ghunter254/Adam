using System.Linq.Expressions;

namespace Exercises;


// Exercise:
// 1. Create a new class in another file called Calculator.cs
// 2. In the Calculator class, create methods for basic arithmetic operations: Add, Subtract, Multiply, Divide
// 3. Each method should take two parameters and return the result
// 4. Make sure to use try-catch to handle errors where appropriate.
// 5. The methods should be static so they can be called without creating an instance of the Calculator class.

class Steve
{
     public static void Run()
    {

        try
        {
            Calculator.Multiplication(12, 10);
        Calculator.Division(10, 12);
        Calculator.Addition(12, 23);
        Calculator.Subtraction(12, 23);
            
        }
        catch (FormatException)
        {
            Console.WriteLine($"Error: What you have entered is invalid. Use numbers only");
        }

        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: You cannot divide by zero");
        }

    }
    



}
class Calculator
{

    public static void Addition(double num1, double num2)
    {
        Console.WriteLine($"Result of Addition: {num1 + num2}");
    }
    public static void Subtraction(double num1, double num2)
    {
        Console.WriteLine($"Result of Subtraction: {num1 - num2}");
    }
    public static void Multiplication(double num1, double num2)
    {
        Console.WriteLine($"Result of Multiplication: {num1 * num2}");
    }
    //Wow I was using integers throughout and then the division obviously didn't work so I cahnged that shi to a double.
    public static void Division(double num1, double num2)
    {
        Console.WriteLine($"Result of Division: {num1 / num2}");
    }

}