namespace Lessons;

class IfStateMents
{
    // If if-else and switch statements execute a block of code when a condition evaluates to true.
    // We shall start with a simple if-else statement that executes a block of code depending on a condition.



    public static void Run()
    {
        try
        {
            Console.WriteLine("Please enter your score: ");

            bool success = int.TryParse(Console.ReadLine(), out int score);

            if (success)
            {
                Student student1 = new(score);

                student1.GradeStudent();
                Student2.GradeStudent(score);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed with exception {ex}");
        }
    }

    // Another approach would be to use nested if statements to handle a few conditions.

    public static void Run2()
    {
        try
        {
            Console.WriteLine("Please enter your score: ");

            bool success = int.TryParse(Console.ReadLine(), out int score);

            if (success) // Talk about logical (not) if success == false
            {
                // if (score > 0 && score < 100) // Talk about && and operator 
                // {
                //     Student student1 = new(score);  
                //     student1.GradeStudent();
                //     Student2.GradeStudent(score);
                // }
                // else
                // {
                //     Console.WriteLine("Invalid input");
                // }

                // 2. The 'if-else if-else' ladder
                // Only one of these blocks will ever execute.
            
                if (score >= 90) Console.WriteLine("Grade: A (Excellent)");

                else if (score >= 80) Console.WriteLine("Grade: B (Good)");

                else if (score >= 70) Console.WriteLine("Grade: C (Average)");
                
                else if (score >= 60) Console.WriteLine("Grade: D (Passing)");
                
                else 
                {
                    Console.WriteLine("Grade: F (Failing)");
                }

                if (score == 100)
                {
                    Console.WriteLine("Bonus: Perfect score!");
                }
            }

            else
            {
                Console.WriteLine("Invalid input");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed with exception {ex}");
        }
    }

}
class Student
{
    public int score;

    public Student(int score)
    {
        this.score = score;
    }

    public void GradeStudent()
    {
        if (score < 60)
        {
            Console.WriteLine("Student failed.");
        }
        // Talk about else if
        else
        {
            Console.WriteLine("Student passed.");
        }
    }

}

// Example with a static Class.
class Student2
{
    
    public static void GradeStudent(int score)
    {
        if (score < 60)
        {
            Console.WriteLine("Student failed.");

            if (score > 50)
            {
                Console.WriteLine("Your grade is A");
            }
            else
            {
                Console.WriteLine("You have failed. No reason for Grade. Bring your parents.");
            }
        }
        else
        {
            Console.WriteLine("Student passed.");
        }
    }
}

