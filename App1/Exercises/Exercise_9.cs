
/*
Exercise: The FinTech Mortgage Calculator

Context:
You have been hired by a startup bank, "NeoLend." 
They need a console application that helps customers understand their home loans.
Mortgages are complex: you have to qualify first, and then the payments 
change slightly over time (interest vs. principal) even if the total payment is fixed.

Goal:
Build a "Loan Originator" system that:
1. Qualifies the user based on Debt-to-Income ratio (Using a WHILE Loop).
2. Generates a month-by-month repayment schedule (Using a FOR Loop).
3. Formats money correctly and handles the math precision.

-------------------------------------------------------------------

PART 1: RESEARCH REQUIREMENTS (The "FinTech Tools")
To work in finance, your code must be precise and your UI clean.
Find out how to do the following:

1. CURRENCY FORMATTING
   - We don't want to see "1500.555555". We want "$1,500.56".
   - Search Term: "C# string format currency".

2. COMPOUND INTEREST MATH
   - The formula for a mortgage payment involves powers (exponents).
   - You cannot write `number ^ 10` in C#.
   - Search Term: "C# Math.Pow example".

3. CONSOLE CLEANING
   - When the user passes qualification, clear the screen so the report 
     looks like a fresh document.
   - Search Term: "C# Console.Clear".

-------------------------------------------------------------------

PART 2: THE LOGIC FLOW

PHASE 1: THE QUALIFICATION ENGINE (The WHILE Loop)
- Banks use a "Debt-to-Income Ratio" (DTI). 
- DTI = (Total Monthly Debts / Total Monthly Income) * 100.
- A user CANNOT get a loan if their DTI is greater than 43%.

- LOGIC:
  - Create a method `RunQualification()`.
  - Start a WHILE loop.
  - Inside the loop:
    - Ask for Monthly Income.
    - Ask for Current Monthly Debts (Credit cards, car loans, etc.).
    - Calculate DTI.
  - CONDITIONS:
    - If DTI > 43%: Print (Red Text) "Declined. Debt ratio too high." 
      and RESTART the loop (ask them to enter new values, assuming they paid off debt).
    - If DTI <= 43%: Print (Green Text) "Approved!" and BREAK the loop.

PHASE 2: THE AMORTIZATION SCHEDULE (The FOR Loop)
- Once approved, ask for:
  - Loan Amount (e.g., $300,000)
  - Interest Rate (e.g., 5.0 for 5%)
  - Loan Term in Years (e.g., 30)

- CALCULATE MONTHLY PAYMENT (The "M" variable):
  - Formula: M = P * ( r * (1+r)^n ) / ( (1+r)^n - 1 )
  - P = Loan Amount
  - r = Monthly Interest Rate (Annual Rate / 100 / 12)
  - n = Total Months (Years * 12)
  - (Use Math.Pow for the ^ part).

- THE LOOP (The Schedule):
  - Create a FOR loop that runs from month 1 to month n.
  - Inside the loop, for every month:
    1. Calculate Interest Payment = Current Balance * r.
    2. Calculate Principal Payment = Total Monthly Payment - Interest Payment.
    3. Update Current Balance = Current Balance - Principal Payment.
    4. Print the row: "Month X | Payment: $... | Principal: $... | Interest: $... | Balance: $..."

- VISUALS & MODULO (%):
  - Every 12 months (year % 12 == 0), print a separator line: 
    "--- END OF YEAR ---" to make it readable.

-------------------------------------------------------------------

REQUIRED CLASSES

1. class LoanApplicant
   - Fields: Income, Debt, IsQualified.
   - Method: CalculateDTI().

2. class MortgageEngine
   - Method: CalculateMonthlyPayment(...).
   - Method: GenerateReport(...).

-------------------------------------------------------------------

EXPECTED OUTPUT EXAMPLE

> --- NEOLEND QUALIFICATION ---
> Enter Income: 5000
> Enter Debts: 3000
> (Red Text) DTI is 60%. DECLINED. Please try again.
> 
> Enter Income: 6000
> Enter Debts: 1000
> (Green Text) DTI is 16%. APPROVED.

(Screen Clears)

> --- LOAN DETAILS ---
> Loan Amount: 200000
> Rate (%): 5
> Years: 30

> --- REPAYMENT SCHEDULE ---
> Month 1 | Pay: $1,073.64 | Prin: $240.31 | Int: $833.33 | Bal: $199,759.69
> Month 2 | Pay: $1,073.64 | Prin: $241.31 | Int: $832.33 | Bal: $199,518.38
...
> Month 12 | Pay: $1,073.64 | ...
> --- END OF YEAR 1 ---
> Month 13 | ...


*/
