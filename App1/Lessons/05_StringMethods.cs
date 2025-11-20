namespace Lessons
{
    class StringMethods
    {
        public static void Run()
        {
            Console.WriteLine("=== Lesson 5: Strings & Useful String Methods ===\n");

            // Strings are reference types and are IMMUTABLE. 
            // Immutable means once a string is created in memory, it cannot be changed.
            // Any operation that appears to 'modify' a string actually creates a new string.

            string message = "  Hello World  ";

            Console.WriteLine($"Original: '{message}'");

            // .Trim() removes spaces from the beginning and end
            string trimmed = message.Trim();
            Console.WriteLine($"After Trim: '{trimmed}'");

            // .ToUpper() and .ToLower() change the casing
            Console.WriteLine($"Uppercase: {trimmed.ToUpper()}");
            Console.WriteLine($"Lowercase: {trimmed.ToLower()}");

            // .Length returns the number of characters
            Console.WriteLine($"Length of message: {trimmed.Length}");

            // .Contains() checks if a substring exists in the string
            Console.WriteLine($"Does the message contain 'World'? {trimmed.Contains("World")}");

            // .Replace() replaces part of the string with another value
            string replaced = trimmed.Replace("World", "Adam");
            Console.WriteLine($"After Replace: {replaced}");

            // .Substring() extracts part of the string
            string part = trimmed[..5]; // Start at index 0, take 5 characters
            Console.WriteLine($"Substring (first 5 chars): {part}");

            // .IndexOf() finds the position of a substring (returns -1 if not found)
            int index = trimmed.IndexOf("World");
            Console.WriteLine($"Index of 'World': {index}");

            // .Split() splits a string into an array based on a delimiter
            string fullName = "Adam Paul";
            string[] nameParts = fullName.Split(' ');

            Console.WriteLine($"\nFull Name: {fullName}");
            Console.WriteLine($"First Name: {nameParts[0]}");
            Console.WriteLine($"Last Name: {nameParts[1]}");


        }
    }
}
