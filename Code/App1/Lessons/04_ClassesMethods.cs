namespace Lessons;

// When we did OOP  in python we created classes with methods inside them.
// A class is basically like a blueprint for creating objects.
// An object is an instance of a class.
// Methods are functions that belong to a class and can operate on its data.

// In C#, classes are defined using the 'class' keyword followed by the class name.
// Methods inside classes are defined similarly to regular functions but are scoped within the class.


// Structure:
// [access modifier] - [class] - [identifier]
// Access modifiers define the visibility of the class (public, private, protected, internal).
// Public classes can be accessed from anywhere by anyone.
// Internal classes can be accessed only within the same assembly/project.
// Private classes can only be accessed within the same class (rarely used for top-level classes).
// Protected classes can be accessed within the same class and by derived classes (used in inheritance). -> To be studied much later.

// Another important concept is the 'static' keyword.
// Static classes and methods belong to the class itself rather than to any specific instance.
// It will be much clearer when we look at the code below.

// void means the method does not return any value.
// other return types include int, string, bool, double, etc.


class ClassesMethods
{
    public static void Run()
    {
        Console.WriteLine("=== Lesson 4: Classes & Methods ===");

        // Now classes can be of two types: Built-in classes and Custom classes.
        // Built-in classes are provided by the .NET framework, like Console, String, Math, etc.
        // Custom classes are user-defined classes that we create ourselves.

        // Now and example of a built-in class we shall use today is the Math class.
        // The Math class is a static class. This means we do need to create an instance for it.

        double number = 16.0;
        double square = Math.Sqrt(number); // Sqrt is a static method of the Math class.

        // Small Exercise: 
        // 1. Document the most common and popular methods of the Math class in a new file called MathMethods.txt
        // 2. Find other popular built-in classes in C# and document their common methods in the same file.

        Console.WriteLine($"The square root of the number {number} is {square}.");

        // Now let's create our own custom class with methods.
        // Another way to instantiate the class is:
        // Person person1;
        // person1 = new Person("Adam", 20);
        // Or we could also use the new version:
        // Person person1 = new() { Name = "Adam", Age = 20 }; // Using object initializer syntax (Requires public properties)
        Person person1 = new Person("Adam", 20); // Creating an instance of the Person class.
        Person person2 = new Person("Eve", 22); // Creating another instance of the Person class.

        Person person3 = person1; // person3 references the same object as person1.


        person1.Introduce(); // Calling the Introduce method of the Person class.
        person2.Introduce(); // Calling the Introduce method of the Person class.
        person3.Introduce(); // Calling the Introduce method of the Person class.

        // The output will show that each object has its own state (name and age) and the method operates on that state.
        // Changing person3 will also change person1 since they reference the same object.
    }

}

class Person
{
    private readonly string name;
    private readonly int age;

    // Now we shall create a constructor for the Person class.
    // A constructor is a special method that is called when an object of the class is created

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Method to display person's info
    // public method → Can be called from other files/classes.
    public void Introduce()
    {
        Console.WriteLine($"Hello! My name is {name}, and I am {age} years old.");
    }
}


// Exercise:
// 1. Create a new class in another file called Calculator.cs
// 2. In the Calculator class, create methods for basic arithmetic operations: Add, Subtract, Multiply, Divide
// 3. Each method should take two parameters and return the result
// 4. Make sure to use try-catch to handle errors where appropriate.
// 5. The methods should be static so they can be called without creating an instance of the Calculator class.

