/*
Exercise: Vehicle Insurance Quotation System

Goal:
Create a console application that combines all previously learned concepts with
new conditional logic. This program will calculate a vehicle insurance quote
based on user input.

Concepts Used:
- Classes & Fields
- Constructors
- Instance methods
- Static methods
- Console input/output
- Validation using try-catch
- NEW: switch statements
- NEW: if / else if / else statements
- NEW: ternary operator (?)

Requirements (Follow Step-by-Step)

1) Create a class named "Applicant".

2) Inside the Applicant class, create the following FIELDS:
   - string name
   - int age
   - string vehicleType
   - int yearsDriving

3) Create a CONSTRUCTOR for the Applicant class that accepts:
   (string appName, int appAge, string vehicle, int drivingExperience)
   and assigns the values to the class fields.

4) Create an INSTANCE METHOD:
   double CalculateBasePremium()
   
   - This method MUST use a SWITCH statement based on the vehicleType field.
   - It should determine the base premium for the vehicle.
   - Logic:
     - case "Sedan": return 1000.0;
     - case "SUV": return 1200.0;
     - case "Sport": return 1800.0;
     - default: return 1400.0; (For any other input)

5) Create an INSTANCE METHOD:
   double CalculateRiskFactor()
   
   - This method MUST use an IF / ELSE IF / ELSE statement.
   - It should determine the risk multiplier based on the applicant's age and experience.
   - Logic:
     - IF age < 25 OR yearsDriving < 2:
       - return 1.8; (High Risk)
     - ELSE IF age >= 25 AND age < 40:
       - return 1.2; (Medium Risk)
     - ELSE (for everyone else, 40+ with 2+ years experience):
       - return 1.0; (Low Risk)

6) Create an INSTANCE METHOD:
   void DisplayQuote()
   
   - This method will calculate and display the full quote.
   - Inside this method, you must do the following:
     
     a) Call your CalculateBasePremium() method and store the result in a local variable.
     b) Call your CalculateRiskFactor() method and store the result in a local variable.
     c) Calculate the final quote: finalQuote = basePremium * riskFactor
     
     d) Use the TERNARY OPERATOR (?) to create a "policyType" string.
        - The logic is: if the riskFactor is greater than 1.5, the string should
          be "High-Risk Policy". Otherwise, it should be "Standard Policy".
        - (Example: string policyType = (riskFactor > 1.5) ? "High-Risk" : "Standard";)
        
     e) Print a full report to the console, including:
        - Applicant Name
        - Applicant Age
        - Vehicle Type
        - Base Premium
        - Risk Factor
        - Policy Type (from your ternary operator)
        - The FINAL CALCULATED QUOTE (formatted nicely, e.g., as currency)

7) Create two STATIC METHODS inside the Applicant class:

   a) static Applicant RequestApplicantData()
      - This method should:
        - Ask the user to enter their name.
        - Ask the user to enter their age.
        - Ask the user to enter their vehicle type (e.g., "Sedan", "SUV", "Sport").
        - Ask the user to enter their total years of driving experience.
        - Use try-catch blocks to ensure age and yearsDriving are valid integers.
          (If invalid, print an error and use a default value, e.g., age 25, years 5).
        - Return a new Applicant object created from the collected values.

   b) static void Run()
      - This method should:
        - Call RequestApplicantData() and store the returned Applicant object.
        - Call the DisplayQuote() method on that object.



Notes / Restrictions:
- You MUST use a switch statement in CalculateBasePremium.
- You MUST use an if/else if/else statement in CalculateRiskFactor.
- You MUST use a ternary operator in DisplayQuote.
- You MUST use try-catch for handling numeric input in RequestApplicantData.

Final Program Flow (What the program should do when running):
- Ask the user for their name, age, vehicle type, and driving experience.
- Create an Applicant object.
- Calculate the base premium (using switch).
- Calculate the risk factor (using if/else).
- Display a full quote, including the policy type (using ternary) and the final price.

Good luck!
*/