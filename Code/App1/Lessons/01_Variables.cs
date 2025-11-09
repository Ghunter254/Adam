namespace Lessons;

class Variables
// Primitives and Constants. 
//(They are also called value types: int float char double bool -> Then struct and enum to be discussed later): Stored in stack memory
// Later we shall discuss reference types (string (Discussed here), arrays, classes , lists, objects): Stored in heap memory
{
    public static void Run()
    {
        Console.WriteLine("=== Lesson 1: Variables ===");

        // Variables are mutable while constants are not.
        // Variables can be declared without initialization.
        // Constants must be initialized at the time of declaration.

        // Rules for identifiers: 
        // - Must start with a letter or underscore
        // - Cannot start with a number
        // - Can contain letters, numbers, and underscores
        // - Cannot be a reserved keyword
        // - Always use meaningful names
        // Notations include: camelCase, PascalCase, snake_case, strHungarianNotation
        int myNum = 5;               // Integer (whole number)
        double myDoubleNum = 5.99;  // Floating point number
        char myLetter = 'D';        // Character
        string myText = "Hello";    // String
        bool myBool = true;         // Boolean

        const float Pi = 3.14f; // Constant variable (Use PascalCase for constants)

        Console.WriteLine("Integer: " + myNum);
        Console.WriteLine("Double: " + myDoubleNum);
        Console.WriteLine("Character: " + myLetter);
        Console.WriteLine("String: " + myText);
        Console.WriteLine("Boolean: " + myBool);
    }
}