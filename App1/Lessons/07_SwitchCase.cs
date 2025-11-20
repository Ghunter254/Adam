namespace Lessons
{
    /// 
    /// This lesson demonstrates 'switch' and 'ternary' operators.
    /// It uses the 'StudentGrader' class to perform the actual logic,
    /// showing how to call both static and instance methods.
    /// 
    class SwitchCase
    {
        public static void Run()
        {
            try
            {
                Console.WriteLine("--- Lesson: The 'switch' Statement (using static methods) ---");
                DemonstrateSwitchStatement();

                Console.WriteLine("\n--- Lesson: The Ternary Operator (using an instance) ---");
                DemonstrateTernaryOperator();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lesson failed with exception: {ex}");
            }
        }


        /// Demonstrates 'switch' by calling STATIC methods on StudentGrader.

        public static void DemonstrateSwitchStatement()
        {
            // --- 1. 'switch' Statement (Static Method) ---
            Console.WriteLine("Enter a letter grade (A, B, C, D, or F):");
            string grade = Console.ReadLine() ?? string.Empty;

            // Call the STATIC method on the StudentGrader class
            string feedback = StudentGrader.GetFeedbackForGrade(grade);
            Console.WriteLine(feedback);

            // --- 2. 'switch' Expression (Static Method) ---
            Console.WriteLine("\n--- Modern 'switch' Expression ---");
            Console.WriteLine("Enter a numeric score (0-100):");
            int.TryParse(Console.ReadLine(), out int score);

            // Call the other STATIC method
            string gradeFeedback = StudentGrader.GetGradeFromScore(score);
            Console.WriteLine(gradeFeedback);
        }

        /// 
        /// Demonstrates the 'ternary' operator by creating an INSTANCE
        /// of StudentGrader and calling an INSTANCE method on it.
        /// 
        public static void DemonstrateTernaryOperator()
        {
            Console.WriteLine("Enter your score to check if you passed:");
            int.TryParse(Console.ReadLine(), out int score);

            // --- 1. The Standard 'if-else' Way (for comparison) ---
            string result;
            if (score >= 60)
            {
                result = "Passed";
            }
            else
            {
                result = "Failed";
            }
            Console.WriteLine($"Standard if-else result: {result}");

            // --- 2. The Ternary Operator Way (using an instance method) ---
            
            // Create an INSTANCE of StudentGrader
            StudentGrader student1 = new StudentGrader(score);
            
            // Call the INSTANCE method on 'student1'
            string ternaryResult = student1.GetPassFailStatus(); 
            
            Console.WriteLine($"Ternary operator result (from StudentGrader object): {ternaryResult}");
            
            // It can also be used directly (inline)
            Console.WriteLine($"Welcome, {(score > 90 ? "star student" : "student")}!");
        }
    }

    /// This class holds the business logic for grading a student.
    /// switch statements and ternary operators.
    public class StudentGrader
    {
        public int Score;

        public StudentGrader(int score)
        {
            Score = score;
        }

        public string GetPassFailStatus()
        {
            string result = (Score >= 60) ? "Passed" : "Failed";
            return result;
        }

        /// Uses a 'switch' statement to return feedback for a letter grade.

        public static string GetFeedbackForGrade(string grade) // a b c D E A B C D E 
        {
            // We can return directly from a case, which avoids needing 'break'.
            switch (grade.ToUpper()) // .ToUpper() makes the check case-insensitive
            {
                case "A":
                    return "Excellent!";
                case "B":
                    return "Good job!";
                case "C":
                    return "Average.";
                
                // "Roll-Down" / Fall-Through Cases:
                // Both "D" and "F" will execute the same code.
                case "D":
                case "F":
                case "E":
                    return "Needs improvement. Let's review this topic.";
                
                // 'default' is the equivalent of 'else'
                default:
                    return $"'{grade}' is not a recognized letter grade.";
            }
            
        }

        /// Uses a modern C# 8.0+ 'switch expression' to convert a score

        public static string GetGradeFromScore(int score)
        {
            // This is an *expression* (it returns a value)
            string feedback = score switch
            {
                100    => "Perfect score! A+",
                >= 90  => "Grade: A", // Can use relational patterns (>=)
                >= 80  => "Grade: B",
                >= 70  => "Grade: C",
                >= 60  => "Grade: D",
                _      => "Grade: F"  // '_' is the default case
            };
            return feedback;
        }
    }
}