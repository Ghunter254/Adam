// LESSON: DICTIONARIES & ENUMS
//
// What You Will Learn:
// 1. Enums: Creating a strict list of options (No more spelling errors!).
// 2. Dictionaries: The "Key-Value" lookup (Instant speed vs Lists).
// 3. Combining them: Using Enums to organize data.
//
// CONCEPTS USED: Classes, Properties, Loops, Switch Statements.

using System.Collections.Generic; // <--- Required for Dictionary

namespace Lessons
{
    // PART 1: THE ENUM (Enumeration)
    // Problem: If we use strings for categories like "Food" or "Weapon", 
    // a typo ("Weapoon") breaks the code.
    // Solution: Enums restrict the choices to a specific list.
    
    public enum ItemCategory
    {
        Weapon,
        Armor,
        Potion,
        Junk
    }

    // A simple class to represent an Item
    public class GameItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ItemCategory Category { get; set; } // Using the Enum here!

        public GameItem(string name, double price, ItemCategory category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }

    // PART 2: THE DICTIONARY
    // Analogy:
    // List = A Hotel Registry. You find people by Room Number (Index 0, 1, 2).
    // Dictionary = A Phonebook. You find numbers by Name ("Steve" -> "555-1234").
    
    class InventorySystem
    {
        public static void Run()
        {
            Console.WriteLine("=== DICTIONARY & ENUM DEMO ===\n");

            // 1. DECLARING A DICTIONARY
            // Syntax: Dictionary<KeyType, ValueType> name = new ...
            // Key: The thing you search FOR (e.g., String Name).
            // Value: The thing you get BACK (e.g., The full Item object).
            
            Dictionary<string, GameItem> backpack = new Dictionary<string, GameItem>();

            // Creating some items
            GameItem sword = new GameItem("Iron Sword", 150.0, ItemCategory.Weapon);
            GameItem potion = new GameItem("Health Potion", 50.0, ItemCategory.Potion);
            GameItem shield = new GameItem("Wooden Shield", 75.0, ItemCategory.Armor);

            // 2. ADDING ITEMS (.Add)
            // WARNING: Keys must be UNIQUE. You cannot add "Iron Sword" twice.
            
            backpack.Add("Iron Sword", sword); 
            backpack.Add("Health Potion", potion);
            backpack.Add("Wooden Shield", shield);
            
            // Alternative "Safe" Add (Overwrites if exists, Adds if new):
            backpack["Iron Sword"] = sword; 
             

            // 3. LOOKING UP ITEMS (The Power Move)
            // In a List, you'd have to loop to find "Iron Sword".
            // In a Dictionary, it is instant.
            
            string searchKey = "Health Potion";

            // yona -> 096803943;
            // adam -> 850390453;
            // njoros -> 00583834;

            // loop through the list -> check each item ... and confirm if it matches your phone number.

            // if you have a dictionary.
            //  phone["adam"] -> instant access to the number.
            // SAFETY CHECK: Always check .ContainsKey before accessing!

            if (backpack.ContainsKey(searchKey))
            {
                GameItem foundItem = backpack[searchKey];
                
                // Using the ENUM in a Switch
                switch (foundItem.Category)
                {
                    case ItemCategory.Weapon:
                        Console.WriteLine($"You equip the {foundItem.Name}. Damage +10.");
                        break;
                    case ItemCategory.Potion:
                        Console.WriteLine($"You drink the {foundItem.Name}. Glug glug.");
                        break;
                    case ItemCategory.Armor:
                        Console.WriteLine($"You equip the {foundItem.Name}. Defense +5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Item not found!");
            }

            // 4. REMOVING ITEMS
            Console.WriteLine("\nRemoving 'Iron Sword'...");
            backpack.Remove("Iron Sword");

            // 5. LOOPING A DICTIONARY
            // When looping, we get a "KeyValuePair" (KVP).
            // kvp.Key = The String Name
            // kvp.Value = The GameItem Object
            
            Console.WriteLine("\n--- CURRENT BACKPACK CONTENTS ---");
            
            foreach (KeyValuePair<string, GameItem> entry in backpack)
            {
                Console.WriteLine($"Key: {entry.Key} | Price: ${entry.Value.Price}");
            }

        }
    }

    // PART 3: ADVANCED USAGE (State Machine)
    // This is how real games handle states.
    // Instead of string state = "Menu", we use an Enum.

    enum GameState
    {
        MainMenu,
        Playing,
        GameOver
    }

    class GameController
    {
        public static void Run()
        {
            // We can map a State (Key) to a Message (Value)
            Dictionary<GameState, string> stateMessages = new Dictionary<GameState, string>
            {
                { GameState.MainMenu, "Welcome! Press Start." },
                { GameState.Playing, "Game in progress... Pew Pew!" },
                { GameState.GameOver, "YOU DIED. Try again?" }
            };

            // Simulate changing states
            GameState currentState = GameState.Playing;

            Console.WriteLine("\n--- STATE MACHINE TEST ---");
            Console.WriteLine($"Current State: {currentState}");
            
            // Look up the message based on the Enum Key
            Console.WriteLine($"System Message: {stateMessages[currentState]}");
        }
    }

    class DictionaryEnumsProgram
    {
        public static void RunMain()
        {
            InventorySystem.Run();
            GameController.Run();
        }
    }
}