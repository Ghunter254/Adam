namespace Lessons;


class TypeCasting
{
    public static void Run()
    {
        Console.WriteLine("=== Lesson 2: Type Casting ===");
        // Implicit casting (automatically) - from smaller to larger data type
        int myInt = 9;
        double myDouble = myInt; // Automatic conversion

        Console.WriteLine("Implicit Casting:");
        Console.WriteLine("Integer: " + myInt);
        Console.WriteLine("Double: " + myDouble);

        // Checking the types of the casted variables.
        Console.WriteLine("Type of myInt: " + myInt.GetType());
        Console.WriteLine("Type of myDouble: " + myDouble.GetType());

        // Explicit casting (manually) - from larger to smaller data type
        double myDouble2 = 9.78;
        int myInt2 = (int)myDouble2; // Manual conversion -> Can lose data, truncates decimal part

        string age = "20";
        int number = -1;
        // Another method to cast using Convert class
        // int myInt3 = Convert.ToInt32(myDouble2); // Safer and more versatile.
        int myInt3 = Convert.ToInt32(myDouble2);
        int myInt4 = Convert.ToInt32(age);
        bool test = Convert.ToBoolean(number);


        // The convert class has other methods like ToDouble, ToString, ToBoolean, etc.

        Console.WriteLine("Explicit Casting:");
        Console.WriteLine("Double: " + myDouble2);
        Console.WriteLine("Integer: " + myInt2);
        Console.WriteLine("Integer using Convert: " + myInt3);
        Console.WriteLine("String: " + myInt4);
        Console.WriteLine("Boolean conversion: " + test);
    }
}

