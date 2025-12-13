// LESSON: PROPERTIES
//
// What You Will Learn:
// 1. Why 'public' variables are dangerous.
// 2. The Private Backing Field (The Safe).
// 3. The Public Property (The Gatekeeper).
// 4. Auto-Implemented Properties (The Shortcut).
// 5. Read-Only Properties (Immutable data).
// 6. Computed Properties (Arrow Syntax).

namespace Lessons
{
    // CONCEPT 1: THE "FULL" PROPERTY
    // Use this when you need LOGIC (Validation).
    
    class RpgCharacter
    {
        // 1. THE BACKING FIELD (Private)
        // Standard naming: underscore + camelCase
        // No one outside this class can touch this.
        private int _health; 

        // 2. THE PROPERTY (Public)
        // Standard naming: PascalCase (Capitalized)
        public int Health
        {
            get 
            { 
                // When someone asks for .Health, give them the private value.
                return _health; 
            }
            set 
            { 
                // "value" is a special keyword. It is whatever the user is trying to assign.
                // LOGIC: Prevent Health from going below 0 or above 100.
                if (value < 0)
                {
                    _health = 0; // Clamp to min
                }
                else if (value > 100)
                {
                    _health = 100; // Clamp to max
                }
                else
                {
                    _health = value; // Accept valid data
                }
            }
        }

        // CONCEPT 2: AUTO-PROPERTIES
        // Use this when you DON'T need logic, but want to be professional.
        // C# builds the private field for you automatically.
        
        public string Name  { get; set; }// { get; set; } is the magic syntax

        // public string _desc;

        // public string Desc
        // {
        //     get
        //     {
        //         return _desc;
        //     }

        //     set { _desc = "This is Adam"; }
        // }

        public string Description { get; set; } = "This is Adam";


        // CONCEPT 3: READ-ONLY PROPERTIES
        // You can set it in the Constructor, but never again.
        
        public string CharacterClass { get; private set; } // 'private set' locks it from the outside


        // CONCEPT 4: COMPUTED PROPERTIES (Arrow Syntax)
        // It doesn't store data. It calculates it on the fly.
        
        // This is dynamic. If _health is 0, this instantly becomes false.
        public bool IsAlive => Health > 0;   


        // CONSTRUCTOR
        public RpgCharacter(string name, string charClass, int startHealth)
        {
            Name = name;
            CharacterClass = charClass;
            Health = startHealth; // This triggers the 'set' logic above!
            
        }
    }

    class Program
    {
        public static void Run()
        {
            Console.WriteLine("=== RPG CHARACTER CREATOR ===");

            RpgCharacter hero = new RpgCharacter("Aragorn", "Ranger", 100);

            // Test 1: Auto-Property
            Console.WriteLine($"Name: {hero.Name}"); // Works fine

            // Test 2: Read-Only Logic
            // hero.CharacterClass = "Wizard"; // <-- COMPILER ERROR! You cannot change this.
            Console.WriteLine($"Class: {hero.CharacterClass}");

            // Test 3: Validation Logic
            Console.WriteLine("\nAttacking hero for 500 damage...");
            hero.Health = -400; // This tries to set it to -400. The logic clamps it to 0.

            Console.WriteLine($"Current Health: {hero.Health}"); // Should print 0
            Console.WriteLine($"Is Alive? {hero.IsAlive}");      // Should print False
        }
    }
}