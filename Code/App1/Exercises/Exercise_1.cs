namespace Exercises;

class Exercise_1
{
   public static void Run()
   {
      Console.WriteLine("=== Lesson 1: Variables & Type Casting Exercises ===");
      Console.WriteLine("Answer the questions inside this file as comments and code where required.");
      Console.WriteLine("Scroll up in the file to begin answering.\n");
   }
}

/*
---------------------------------------------
SECTION A: THEORY QUESTIONS (Answer in comments)
---------------------------------------------

Feel free to refer to the lesson files if needed.
Use any resources you like, but try to answer in your own words.
Do enough research to understand the concepts.
Visit the official Microsoft C# documentation for more details.
Link: https://learn.microsoft.com/en-us/dotnet/csharp/

1. What is the difference between a variable and a constant in C#?
   Answer: A variable is mutable and can be initialized without declaration, a constant is immutable and must be initialized and declared together

2. Name 5 primitive data types in C#, and give one example use for each.
   Answer:
   Integers - for declaring integer values
   Booleans - for logic operations
   Strings - for declaring words like names or locations
   Doubles - for decimals, has larger space than floats
   Floats - for decimals, has smaller space than doubles

3. What is the difference between implicit and explicit casting?
   Answer:

4. What does the 'f' mean in `float pi = 3.14f;`?
   Answer:

5. What is the difference between:
      (int)myDouble
      Convert.ToInt32(myDouble)
   Answer:

6. What is the purpose of Parse() and TryParse() methods?
This wasnt covered in the lessons so I expect you to research it yourself.
   Answer:


--------------------------------------------------
SECTION B: MULTIPLE CHOICE (Write the letter only)
--------------------------------------------------

1. Which of the following is a valid variable declaration?
   a) int 1age = 10; (can't start with number)
   b) int age-1 = 10; (can't use special characters)
   c) int age = 10; 
   d) int @ = 10; (can't use a keyword/special character)
   Answer: c

2. Which method will NOT crash if the input cannot be converted to an int?
   a) (int)value
   b) Convert.ToInt32(value)
   c) int.Parse(value)
   d) int.TryParse(value, out result)
   Answer:

3. What does explicit casting do?
   a) Converts without loss
   b) May remove decimal part
   c) Always rounds numbers
   d) Prevents data loss
   Answer:


---------------------------------------------------
SECTION C: CODE EXERCISES (Fill in missing code)
---------------------------------------------------

1. Create variables for the following, using correct data types:
   - Your Name
   - Your Age
   - Your Height in meters
   - Whether you are a student (true/false)

   Then print them in one sentence.

   Example Output:
   "My name is Adam, I am 20 years old, 1.75m tall, Student: True"

   // Your code below:
   string name = "Adam";
   int age = 20;
   double height = 1.75;
   bool isStudent = true;

   Console.WriteLine("My name is " + name ", I am " + age " years old, " + height "m tall, Student: " +isStudent);


2. Demonstrate explicit casting:
   Convert 5.92 to an int using BOTH (int) and Convert.ToInt32.
   Print both values and explain the difference in a comment.

   // Your code below:
   double value = 5.92;
   int truncated = (int)value;       // Explain:
   int rounded = Convert.ToInt32(value); // Explain:

   Console.WriteLine(truncated);
   Console.WriteLine(rounded);


3. Demonstrate Parse and TryParse:

   // Convert "42" using int.Parse
   // Convert "42" using int.TryParse
   // Convert "hello" using int.TryParse (should not crash)

   // Your code below:
   string n1 = "42";
   string n2 = "hello";

   int parsedValue = int.Parse(n1);
   Console.WriteLine(parsedValue);

   bool result1 = int.TryParse(n1, out int try1);
   bool result2 = int.TryParse(n2, out int try2);

   Console.WriteLine($"TryParse 1 Successful: {result1}, Value: {try1}");
   Console.WriteLine($"TryParse 2 Successful: {result2}, Value: {try2}");


---------------------------------------------------
SECTION D: GOATED EXERCISE 
---------------------------------------------------

Write a program that:
- Asks the user to enter their age
- Safely converts it using TryParse
- If conversion fails, print "Invalid age!"
- If valid:
    - If age >= 18 print "You are an adult."
    - Else print "You are a minor."

(Put your code below in the Run() method of this class)

*/
