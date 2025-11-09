namespace Exercises;

    /*
    ==============================
    Exercise: Simple Student Info
    ==============================


    Objective:
    Create a small C# program that stores basic information about a student
    and displays it. This exercise will help you practice classes, public properties,
    methods, constructors, and console input/output.

    Instructions / Guidelines:

    1. Create a class called 'Student'.
       - Include two public properties:
         - Name (string)
         - Age (int)

    2. Add a method called 'DisplayInfo()' inside the 'Student' class.
       - This method should print the student's Name and Age to the console.

    3. In the Main method or a separate Run() method, do the following:
       - Ask the user to enter the student's name.
       - Ask the user to enter the student's age.
        - Make sure to validate that age is a positive integer using int.TryParse().
       - Create a Student object and assign the input values to the properties.

    4. Call the DisplayInfo() method on your object to print the student's information.

    Hints:

    - Use Console.WriteLine() to show messages to the user.
    - Use Console.ReadLine() to get input from the user.
    - Remember to convert string input to integer for age using int.TryParse().
    - You can declare a Student object first and then set the properties:
        Student student = new Student();
        student.Name = name;
        student.Age = age;
    - Finally, call the method:
        student.DisplayInfo();

    Example Run:

    Enter student name: Adam
    Enter student age: 20

    Student Info:
    Name: Adam
    Age: 20

    ==============================
    */

