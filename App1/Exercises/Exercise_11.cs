/*
Exercise: The List Manager Toolkit (Building Your Own API)

Context:
You have been hired to build the backend for a Task Management App.
During development, you realized that the standard C# List tools are sometimes dangerous or limited:
1. `RemoveAt(index)` crashes the whole program if the index is wrong.
2. `Remove(item)` only deletes the FIRST matching item, not all of them.
3. There is no built-in way to "Swap" two items (e.g., moving a task up in priority).

Goal:
Instead of writing sloppy code everywhere, you will build a robust Utility Class.
This class (`ListUtils`) will contain STATIC methods that perform these surgeries on lists safely.
Your Main Program will simply be a "Test Bench" to prove your tools work.


PART 1: THE TOOLKIT API (The Logic)

Create a class named `ListUtils`. It should not hold data itself.
It should contain the following STATIC methods:

1. Method: `RemoveIndexSafe`
   - Input: A `List<string>` and an `int index`.
   - Logic:
     - Check if the index is valid (Between 0 and Count-1).
     - If Valid: Remove the item and print "[Success] Removed item...".
     - If Invalid (Negative or too high): Do NOT crash. Print "[Error] Index out of range."

2. Method: `SwapItems`
   - Input: A `List<string>`, `int indexA`, and `int indexB`.
   - Logic:
     - We want to switch the positions of two items.
     - VALIDATION: Ensure BOTH indexes are valid first.
     - SWAP LOGIC: You cannot just say `a = b` and `b = a`. That deletes data.
       (Hint: You need a temporary "Glass" to hold one liquid while you pour the other).

3. Method: `ReplaceAll`
   - Input: A `List<string>`, `string target`, `string replacement`.
   - Problem: `list.Remove("Milk")` only deletes the first "Milk".
   - Logic:
     - Loop through the entire list.
     - Every time you find `target`, overwrite it with `replacement`.
     - Count how many changes you made.

4. Method: `PurgeDuplicates` (The Challenge)
   - Input: A `List<string>`.
   - Logic:
     - The list has messy data: "Apple", "Banana", "Apple", "Apple".
     - You must modify the list so only UNIQUE items remain.
     - (Hint: You might need to create a temporary "Clean List" inside the method, 
       fill it with only unique items, and then copy it back to the original).


PART 2: THE TEST BENCH (The Main Program)

In your `Program.cs`, you must write code to PROVE your tools work.
Do not ask for user input. Hardcode the tests.

1. Setup:
   - Create a list: `{"Milk", "Eggs", "Milk", "Bread", "Milk", "Cheese"}`.
   - Print the original list.

2. Test Safe Remove:
   - Try to remove Index 100 (Should print Error).
   - Try to remove Index 1 (Should succeed).

3. Test Replace All:
   - Replace all "Milk" with "Oat Milk".
   - Print the result.

4. Test Swap:
   - Swap Index 0 with the Last Index.
   - Print the result.

5. Test Purge:
   - Add duplicate items again.
   - Run PurgeDuplicates.
   - Print the final result.


EXPECTED OUTPUT

> --- ORIGINAL LIST ---
> [Milk] [Eggs] [Milk] [Bread] [Milk] [Cheese] 

> --- TEST 1: REMOVE SAFE ---
> [Error] Index 100 is out of range.
> [Success] Removed 'Eggs' at index 1.

> --- TEST 2: REPLACE ALL ---
> [Report] Replaced 3 instances of 'Milk'.
> Current List: [Oat Milk] [Oat Milk] [Bread] [Oat Milk] [Cheese]

> --- TEST 3: SWAP ---
> [Success] Swapped index 0 with index 4.
> Current List: [Cheese] [Oat Milk] [Bread] [Oat Milk] [Oat Milk]

> --- TEST 4: PURGE DUPLICATES ---
> [Success] List cleaned.
> Final List: [Cheese] [Oat Milk] [Bread]


Good luck, Backend Engineer.
*/