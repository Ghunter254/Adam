/*
Exercise: Project Exodus - Mars Colony Architect

Context:
You are the AI Overseer of the first permanent human settlement on Mars.
Your job is to manage the colony's infrastructure and population over a period of 30 days.

This is not just a calculator. It is a simulation of dependent systems.
- Buildings (Array) produce Resources.
- Colonists (List) consume Resources.
- Resources (Properties) determine survival.

If you design this poorly, your main loop will become a mess of spaghetti code.
Structure your classes so they "talk" to each other cleanly.

-------------------------------------------------------------------

PART 1: ARCHITECTURAL REQUIREMENTS (The Design)

1. ENCAPSULATION (The Life Support System)
   - You must have a class `ColonyStats` or `ResourceManager`.
   - Resources (`Oxygen`, `Water`, `Energy`) MUST be Properties.
   - LOGIC IN SETTERS:
     - Resources cannot go below 0 or above 100.
     - If Oxygen drops below 20, the property itself should change a status flag 
       (e.g., `IsCriticalState = true`) or print a Red Alert to the console immediately.
     - You cannot rely on the main loop to check for negative numbers. The Class must protect itself.

2. THE MAP (The Infrastructure)
   - You need a 3x3 or 4x4 grid (2D Array) representing the colony sectors.
   - Each slot can hold a building type (e.g., "Solar Panel", "Greenhouse", "Habitat", "Empty").
   - You need a method that scans this array to calculate total daily production.
     - Example: 1 Solar Panel = +10 Energy/day.
     - Example: 1 Greenhouse = +5 Water/day.

3. THE POPULATION (The Workforce)
   - You need a `List<Colonist>`.
   - Each Colonist has a Name, Job, and Health.
   - The List is dynamic. People are born (Add) and people die (Remove).
   - Every day, you must loop through the list:
     - Every colonist consumes 1 Water and 1 Oxygen.
     - If resources are 0, the colonist takes damage (Health decreases).
     - If Health <= 0, remove them from the list.

-------------------------------------------------------------------

PART 2: THE SIMULATION LOOP (The Game)

Run a simulation for 30 "Days" (Loops).
Every Day, the following sequence happens:

1. EVENT PHASE (Randomness)
   - Generate a random event (e.g., "Dust Storm", "Meteor Strike", "Equipment Failure").
   - A "Meteor" might destroy a building at a specific Array Index [x,y].
   - A "Plague" might lower the health of everyone in the List.

2. PRODUCTION PHASE (Array Logic)
   - Scan the 2D Map. Calculate total Energy/Water produced by buildings.
   - Add to Resource Properties.

3. CONSUMPTION PHASE (List Logic)
   - Loop through the `List<Colonist>`.
   - Deduct resources.
   - Check for deaths. (Hint: You cannot remove items from a list *while* looping through it with foreach. You might need a "for" loop or a separate "dead colonists" list).

4. REPORT PHASE
   - Print the Day Number, Population Count, and Resource Levels.
   - Visuals: Use ConsoleColor to indicate status (Green = Good, Red = Critical).

-------------------------------------------------------------------

REQUIRED CLASSES (Minimum Design)

1. class Colonist
   - Properties: Name, Health, Job.
   - Methods: Eat(), TakeDamage().

2. class ColonyMap
   - Field: string[,] Grid (The 2D Array).
   - Method: ScanProduction() -> returns a struct or object with total resource gains.

3. class LifeSupport (or ColonyManager)
   - Properties: Oxygen, Water, Energy (with validation logic).
   - Method: UpdateDay() -> handles the math of inputs/outputs.

4. class Simulation (The Main Controller)
   - Holds the List<Colonist>.
   - Holds the ColonyMap.
   - Holds the LifeSupport.
   - Runs the "Day Loop".

-------------------------------------------------------------------

SCENARIO FOR TESTING

> Start with:
  - 10 Colonists.
  - Resources: 50 Oxygen, 50 Water, 50 Energy.
  - Map: 2 Solar Panels, 1 Greenhouse, 1 Habitat.

> Expected Challenge:
  - Your population will consume resources faster than you produce them.
  - You need to build logic (maybe in the loop) to build NEW buildings 
    if you have enough Energy.
  - OR, allow the user to input an action every day (e.g., "Build Greenhouse").

Good luck, Commander. The lives of the colonists are in your architecture.
*/