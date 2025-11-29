/*
Exercise: Project Chronos - The Time Travel Simulator

Context:
You have been recruited as the Lead Engineer for the "Chronos" project. 
Your mission is to build the software that controls the world's first stable 
time machine. 

This is a high-stakes simulation. The interface must be readable, 
the controls must be robust, and the physics engine must handle 
the unpredictability of time travel.

Goal:
Build a console application that:
1. Forces the user to "calibrate" the machine (Using a WHILE Loop).
2. Simulates the journey year-by-year (Using a FOR Loop).
3. Handles random events and visual alerts (Using Conditionals & Research).

-------------------------------------------------------------------

PART 1: RESEARCH REQUIREMENTS (The "Engineering Modules")
This project requires you to use C# tools we haven't explicitly covered yet. 
As a lead engineer, you must use Google or Microsoft Documentation to find 
how to use the following commands:

1. SIMULATION DELAY
   - Time travel isn't instant. You need to find a command that pauses the 
     program for a specific time (e.g., 600 milliseconds) between years.
   - Search Term: "C# Thread Sleep".

2. VISUAL ALERTS
   - The console cannot just be white text. 
   - "Normal" travel should be Gray.
   - "DANGER" events should be Red.
   - "GOOD" events should be Green.
   - Search Term: "C# change console text color".

3. ROBUST INPUTS
   - When calibrating, if the user types "  stabilize  " (with spaces) 
     or "STABILIZE" (caps), the system must accept it.
   - Search Term: "C# string trim and tolower".

4. QUANTUM RANDOMNESS
   - Time is unpredictable. You need to generate a random number (1-10) 
     every single year to decide what happens.
   - Search Term: "C# Random class example".

5. SAFETY LIMITS
   - Energy should never go above 100 or below 0. 
   - Search Term: "C# Math.Clamp" or "C# Math.Min Math.Max".

-------------------------------------------------------------------

PART 2: THE LOGIC FLOW (Business Rules)

PHASE 1: THE CALIBRATION SEQUENCE (The WHILE Loop)
- The machine starts with `IsCalibrated = false` and `Energy = 0`.
- Create a method (e.g., `CalibrateCore`) that runs a WHILE loop.
- The loop continues WHILE the Energy is less than 100.
- Inside the loop:
  - Print current energy in YELLOW.
  - Ask for input: "Stabilize" (+20 Energy) or "Unstable" (-10 Energy).
  - (Remember to sanitize the input using your research from Part 1).
- Once Energy reaches 100, set `IsCalibrated = true` and stop the loop.

PHASE 2: THE JOURNEY (The FOR Loop)
- Ask the user for the `Start Year` and the `Destination Year`.
- Create a method (e.g., `StartTravel`) that loops through every year.

- CRITICAL LOGIC: 
  - The loop must work for Future Travel (e.g., 2025 -> 2030).
  - The loop must ALSO work for Past Travel (e.g., 2030 -> 2025).
  - (Hint: You need to decide if the loop counts UP (i++) or DOWN (i--) 
    based on the destination).

- INSIDE THE JOURNEY LOOP:
  1. Pause for 600ms (Thread Sleep).
  2. Generate a Random Number (1-10).
  3. Apply Logic:
     - If Random is 1: "Dimensional Rift" (Energy -20, Color RED).
     - If Random is 10: "Supernova Assist" (Energy +10, Color GREEN).
     - All other numbers: "Stable Cruise" (Energy -3, Color GRAY).
  4. Check for catastrophic failure:
     - If Energy drops to 0 or less, break the loop immediately 
       and print "MISSION FAILED: LOST IN TIME".

-------------------------------------------------------------------

REQUIRED CLASSES (Suggested Structure) This is a simple version. More marks if you use the three class system

1. class TimeMachine
   - Should hold the state (CurrentYear, Energy, IsCalibrated).
   - Should have methods to change energy (and keep it between 0-100).

2. class PhysicsEngine
   - Should hold the Logic (The Loops, The Randomness, The Colors).

-------------------------------------------------------------------

EXPECTED OUTPUT EXAMPLE

> --- SYSTEM BOOT ---
> Current Energy: 0%
> Enter command:   STABILIZE  
> (Yellow Text) Energy increased to 20%...
> ... (Loop continues until 100%) ...
> SYSTEM CALIBRATED.

> Enter Start Year: 2025
> Enter Destination Year: 2020 

> TRAJECTORY SET: GOING BACK IN TIME.
> (0.6s pause)
> Year 2025: Stable Cruise. Energy 97%
> (0.6s pause)
> Year 2024: (Red Text) !! DIMENSIONAL RIFT !! Energy 77%
> (0.6s pause)
> Year 2023: Stable Cruise. Energy 74%
> ...
> Year 2020: ARRIVAL CONFIRMED.

Good luck, Engineer.
*/