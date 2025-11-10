

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

            if (success)
            {
                if (score < 0 || score > 100)
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
                else
                {
                    Student student1 = new(score);  
                    student1.GradeStudent();
                    Student2.GradeStudent(score);
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
        }
        else
        {
            Console.WriteLine("Student passed.");
        }
    }
}

