/*
Exercise: Project "Event Horizon" - Interstellar Logistics Calculator

Goal:
This is a design challenge. Your goal is to build a program that
calculates the cost and time for a cargo shipment to different planets.

Unlike the last exercise, you will NOT be told exactly what methods or
fields to create. You must design the classes yourself to solve the problem.
You must invent the "business logic" (the rules) for the calculator.

The "Research" Part:
The "research" for this project is to invent your own pricing model.
For example, you must decide:
- How much does it cost to go to Mars vs. Europa?
- How much does cargo weight add to the cost?
- Does a certain destination (like a "War Zone") add a special fee?
- How do you calculate travel time?

You must use your knowledge of if, switch, and operators to build this logic.

-------------------------------------------------------------------

THE CHALLENGE

You need to create a console application that acts as a shipping
quote calculator for an interstellar logistics company.

A user will provide their desired DESTINATION and the CARGO WEIGHT.
Your program will calculate and display a full quote.

-------------------------------------------------------------------

REQUIRED CLASSES

You must create and use at least these two classes:

1) class Shipment
   - This class should be responsible for HOLDING data.
   - Think about what information a "Shipment" needs to have.
     (Hint: It will probably store the inputs you get from the user).

2) class QuoteEngine
   - This class is responsible for DOING the work.
   - It should contain all your custom "business logic" (your
     invented rules).
   - It will likely have methods that take a Shipment object (or its
     data) and calculate the final quote.

-------------------------------------------------------------------

REQUIRED INPUTS (Get from the User)

1. Destination (string): e.g., "Mars", "Europa", "Alpha Centauri"
2. Cargo Weight (int): e.g., 500 (in kg)

-------------------------------------------------------------------

REQUIRED OUTPUTS (Display to the User)

1. Base Cost (double): The starting price just for the destination.
2. Weight Fee (double): The extra charge based on cargo weight.
3. Special Fees (double): Any extra fees (e.g., "Hazardous Zone Fee"
   for Europa, "Long Haul Fee" for Alpha Centauri).
4. Total Cost (double): The sum of all costs.
5. Estimated Travel Time (int): In days.
6. Trip Notes (string): A note explaining the quote, e.g.,
   "Standard priority shipment." or "High-risk surcharge applied."

-------------------------------------------------------------------

LOGIC GUIDANCE (Questions to help you "think")

- How will your QuoteEngine know the difference between "Mars" and "Europa"?
  (Hint: A switch statement is great for matching strings).

- How will you calculate the Weight Fee?
  (Hint: An if/else if/else block is great for number ranges,
  e.g., 0-100kg, 101-1000kg, 1000+ kg).

- How will you handle a destination that has *both* a base cost AND
  a special fee?

- Where will you get the data from the user? (Hint: A static method
  like in the last exercises is a good pattern).

- How will the Program.cs file start the whole application?

-------------------------------------------------------------------

EXAMPLE PROGRAM FLOW (What the console might look like)

> Welcome to Interstellar Logistics!
> Please enter destination: Europa
> Please enter cargo weight (kg): 1200

> --- Generating Quote ---
> Destination: Europa
> Base Cost: $35,000.00
> Weight Fee (1200kg): $8,000.00
> Special Fees: $15,000.00 (Hazardous Zone Surcharge)
>
> TOTAL COST: $58,000.00
> EST. TRAVEL TIME: 95 Days
> Trip Notes: High-risk surcharge applied.

Good luck!
*/