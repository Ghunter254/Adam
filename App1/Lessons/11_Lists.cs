// LESSON: LISTS (System.Collections.Generic)
//
// What You Will Learn:
// 1. The limitation of Arrays (Fixed Size).
// 2. What a List is (Dynamic Size).
// 3. How to Add, Remove, and Count items.
// 4. The 'foreach' loop (The cleaner way to loop).
// 5. Built-in List superpowers: Sort, Reverse, Contains.


using System.Collections.Generic; // <--- CRITICAL: Lists live inside here!

// Constructors of Lists:
// List<T>() : Initializes a new instance of the List<T> class that is empty and has the default initial capacity.
// List<T>(IEnumerable<T>) : Initializes a new instance of the List<T> class that contains elements copied from the 
// specified collection and has sufficient capacity to accommodate the number of elements copied.
// List<T>(Int32) : Initializes a new instance of the List<T> class that is empty and has the specified initial capacity.

// Properties of Lists:
// Capacity: The number of elements that the List can store before resizing is required.
// Count: The number of elements that are actually in the List.
// item[Int32]: Gets or sets the element at the specified index.
namespace Lessons
{
    // PART 1: THE CONCEPT
    //
    // Analogy:
    // Array = An Egg Carton. It has exactly 12 spots. You cannot fit a 13th egg.
    // List  = A Notepad. You can write 1 line, or 100 lines. You can rip a page out.
    //         It grows and shrinks as you need it.
    // Allows duplicate elements and accepts null values for reference types.

    class PartyPlanner
    {
        public void ManageGuestList()
        {
            Console.WriteLine("=== PARTY GUEST MANAGER ===");

            // DECLARATION
            // Syntax: List<DataType> name = new List<DataType>();
            // Arrays: string[] varName = new string[10];
            // List<string> guests = new List<string>(varName);
            List<string> guests = new List<string>();
            // List<string> guests = new();

            // 1. ADDING ITEMS (.Add)
            // We don't need to know the size beforehand!
            guests.Add("John");
            guests.Add("Sarah");
            guests.Add("Mike");
            guests.Add("Emily");

            List<string> guests2 =
            [
                "John",
                "Sarah",
                "Mike",
                "Emily",
            ];

            Console.WriteLine($"Current Guest Count: {guests.Count}"); // .Count, not .Length

            // 2. REMOVING ITEMS (.Remove)
            // Mike said he can't make it.
            Console.WriteLine("Removing Mike...");
            guests.Remove("Mike");

            // 3. CHECKING EXISTENCE (.Contains)
            // Is Sarah invited?
            if (guests.Contains("Sarah"))
            {
                Console.WriteLine("Sarah is on the list.");
            }

            // 4. ACCESSING BY INDEX (Just like arrays)
            // Who is the first person?
            Console.WriteLine($"First guest: {guests[0]}");

            Console.WriteLine("\n--- FINAL GUEST LIST ---");

            // 5. LOOPING (The 'foreach' loop)
            // Read as: "For every 'person' inside the 'guests' list..."
            // We don't need 'int i = 0' here. It just grabs every item one by one.
            foreach (string person in guests)
            {
                Console.WriteLine($"- {person}");
            }
            Console.WriteLine();
        }
    }


    // PART 2: LISTS OF NUMBERS & HELPER METHODS
    //
    // Lists come with powerful tools to organize data.
    // We will build a High Score system.

    class HighScoreTracker
    {
        public static void Run()
        {
            Console.WriteLine("=== ARCADE HIGH SCORES ===");
            
            // Initialize with some values immediately (Collection Initializer)
            List<int> scores = [ 500, 1200, 300, 9000, 150 ];

            Console.WriteLine("New score received: 4500");
            scores.Add(4500);

            // SORTING (.Sort)
            // Sorts the list from Smallest to Largest automatically
            scores.Sort();
            Console.WriteLine("Sorted scores (Low -> High)...");

            // REVERSING (.Reverse)
            // Flips the list. Now it is Largest -> Smallest
            scores.Reverse();
            Console.WriteLine("Reversed (High -> Low)...");

            Console.WriteLine("\n--- LEADERBOARD ---");
            int rank = 1;
            
            // Using foreach to display
            foreach (int score in scores)
            {
                Console.WriteLine($"Rank {rank}: {score} pts");
                rank++; // Manually increment rank for display
            }

            // MATH HELPERS
            // Lists don't have .Sum() built-in by default without LINQ (advanced),
            // so we do it the old fashioned way for practice.
            int sum = 0;
            foreach (int score in scores)
            {
                sum += score;
            }
            Console.WriteLine($"\nTotal Points Scored: {sum}");
            Console.WriteLine($"Highest Score: {scores[0]}"); // Since we sorted and reversed, index 0 is max
        }
    }


    // ---------------------------------------------------------
    // PART 3: FULL PROGRAM DEMO
    // "The Shopping Cart"
    // This allows the user to Add/Remove items dynamically.
    // ---------------------------------------------------------

    class ShoppingCart
    {
        public static void Run()
        {
            List<string> cart = new List<string>();
            bool isShopping = true;

            Console.WriteLine("=== DYNAMIC SHOPPING CART ===");
            
            while (isShopping)
            {
                // Show current status
                Console.WriteLine($"\nYour Cart has {cart.Count} items.");
                
                Console.WriteLine("Choose action: [1] Add Item  [2] Remove Item  [3] Checkout/Exit");
                string input = Console.ReadLine() ?? "";

                if (input == "1")
                {
                    Console.Write("What do you want to add? ");
                    string item = Console.ReadLine() ?? "";
                    
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        cart.Add(item);
                        Console.WriteLine($"{item} added!");
                    }
                }
                else if (input == "2")
                {
                    Console.Write("Type exact name of item to remove: ");
                    string itemToRemove = Console.ReadLine() ?? "";

                    // .Remove returns TRUE if it found the item, FALSE if it didn't
                    bool wasRemoved = cart.Remove(itemToRemove);
                    
                    if (wasRemoved)
                    {
                        Console.WriteLine($"{itemToRemove} removed from cart.");
                    }
                    else
                    {
                        Console.WriteLine("Item not found in cart.");
                    }
                }
                else if (input == "3")
                {
                    isShopping = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }

            // Checkout Summary
            Console.Clear();
            Console.WriteLine("=== RECEIPT ===");
            foreach (string product in cart)
            {
                Console.WriteLine($"[x] {product}");
            }
            Console.WriteLine("Thank you for shopping!");
        }
    }


    class ListsDemo
    {
        public static void Run()
        {
            Console.WriteLine("Choose a List Demo:");
            Console.WriteLine("1. Party Planner (Basic List Operations)");
            Console.WriteLine("2. High Score Tracker (Sort & Reverse)");
            Console.WriteLine("3. Shopping Cart (Interactive Add/Remove)");

            Console.Write("Enter choice: ");
            string input = Console.ReadLine() ?? "";
            Console.WriteLine();

            if (input == "1")
            {
                PartyPlanner planner = new PartyPlanner();
                planner.ManageGuestList();
            }
            else if (input == "2")
            {
                HighScoreTracker.Run();
            }
            else if (input == "3")
            {
                ShoppingCart.Run();
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}