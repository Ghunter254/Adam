/*
   LESSON PART 2: The 'while' Loop
   Context: We use this when we need to keep doing something UNTIL a condition changes.
   
   Scenario: 
   A security checkpoint. The user must keep entering the password until 
   they get it right, OR until they decide to type "exit" to quit.
*/

namespace Lessons;

public class SecuritySystem
{
    // Field: The correct password (hardcoded for this lesson)
    private string correctPassword = "admin"; 


    // INSTANCE METHOD: The While Loop Logic
    public void StartLoginSequence()
    {
        Console.WriteLine("\n--- SECURE SERVER LOGIN ---");
        
        string input = ""; // Variable to store user input
        int attempts = 0;  // Counter (optional, but good for tracking)

        // THE WHILE LOOP
        // Structure: while (Condition is True) { Do Stuff }
        
        // Logic: Keep looping AS LONG AS the input is NOT the correct password
        while (input != correctPassword)
        {
            Console.Write("Please enter password (or type 'exit' to quit): ");
            input = Console.ReadLine() ?? "";
            
            attempts++; // Increment attempts

            // 1. Check for Exit command
            if (input == "exit")
            {
                Console.WriteLine("Login cancelled by user.");
                return; // 'return' breaks out of the method entirely, stopping the loop
            }

            // 2. Check for Correct Password
            if (input == correctPassword)
            {
                Console.WriteLine($"\nACCESS GRANTED. Welcome, Admin.");
                Console.WriteLine($"Total attempts: {attempts}");
                // The loop will end naturally now because input == correctPassword
            }
            else
            {
                Console.WriteLine(">> Access Denied. Try again.");
                // The loop restarts because input != correctPassword
            }
        }

        // while (true)
        // {
        //     Console.WriteLine("Yohhhhhh");
        // }
    }

    // STATIC METHOD: Helper to run it
    public static void Run()
    {
        SecuritySystem system = new();
        system.StartLoginSequence();
    }
}