namespace NeoLend;
public class LoanApplicant
{
    public double MonthlyIncome { get; set; }
    public double MonthlyDebt { get; set; }

    // Helper method to do the math
    public double CalculateDTI()
    {
        if (MonthlyIncome == 0) return 0; // Prevent divide by zero error
        return (MonthlyDebt / MonthlyIncome) * 100;
    }
}

public class MortgageEngine
{
   
    public double CalculateMonthlyPayment(double loanAmount, double annualRate, int years)
    {
        
        double monthlyRate = (annualRate / 100) / 12;

       
        int totalMonths = years * 12;

        double compoundFactor = Math.Pow(1 + monthlyRate, totalMonths);

     
        double numerator = loanAmount * monthlyRate * compoundFactor;
        double denominator = compoundFactor - 1;

        return numerator / denominator;
    }

    public void GenerateReport(double loanAmount, double annualRate, int years)
    {
        double monthlyPayment = CalculateMonthlyPayment(loanAmount, annualRate, years);
        double monthlyRate = (annualRate / 100) / 12;
        double currentBalance = loanAmount;
        int totalMonths = years * 12;

        Console.Clear(); // RESEARCH TOPIC: Cleaning the screen
        Console.WriteLine("--- MORTGAGE AMORTIZATION SCHEDULE ---");
        Console.WriteLine($"Loan Amount: {loanAmount:C0}"); // :C0 means Currency with 0 decimals
        Console.WriteLine($"Rate: {annualRate}%");
        Console.WriteLine($"Monthly Payment: {monthlyPayment:C2}"); // :C2 means Currency with 2 decimals
        Console.WriteLine("-------------------------------------------------------------------------------");

        // THE FOR LOOP (The Schedule)
        for (int month = 1; month <= totalMonths; month++)
        {
            
            double interestPayment = currentBalance * monthlyRate;

            double principalPayment = monthlyPayment - interestPayment;

            currentBalance = currentBalance - principalPayment;

        
            if (currentBalance < 0) currentBalance = 0;

            Console.WriteLine($"Month {month, -4} | Pay: {monthlyPayment:C2} | Prin: {principalPayment:C2} | Int: {interestPayment:C2} | Bal: {currentBalance:C2}");

            // RESEARCH TOPIC: MODULO SEPARATOR
            // If the month is divisible by 12 (12, 24, 36...), it's the end of a year.
            if (month % 12 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"--- END OF YEAR {month / 12} ---");
                Console.ResetColor();
            }
        }
    }
}


class Program
{
    
    static void RunQualification()
    {
        LoanApplicant applicant = new LoanApplicant();
        bool isApproved = false;

        Console.WriteLine("--- NEOLEND MORTGAGE ORIGINATOR ---");

        // THE WHILE LOOP
        // Keep asking until they are approved OR they rage quit (Ctrl+C)
        while (!isApproved)
        {
            try
            {
                Console.Write("\nEnter Total Monthly Income: ");
                applicant.MonthlyIncome = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter Total Monthly Debts: ");
                applicant.MonthlyDebt = double.Parse(Console.ReadLine() ?? "0");

                double dti = applicant.CalculateDTI();

                if (dti > 43)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"DTI is {dti:F2}%. DECLINED. Ratio must be under 43%.");
                    Console.WriteLine("Please pay off some debt and try again.");
                    Console.ResetColor();
                    // Loop continues...
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"DTI is {dti:F2}%. APPROVED.");
                    Console.ResetColor();
                    isApproved = true; // This breaks the loop
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input. Please enter numbers only.");
            }
        }
        
        // Wait for user before clearing screen
        Console.WriteLine("\nPress Enter to generate loan docs...");
        Console.ReadLine();
    }

    static void Mainzero(string[] args)
    {
        
        RunQualification();

        try 
        {
            Console.Clear();
            Console.WriteLine("--- LOAN DETAILS ---");
            
            Console.Write("Enter Loan Amount (e.g. 300000): ");
            double amount = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Annual Interest Rate (e.g. 5.5): ");
            double rate = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Term in Years (e.g. 30): ");
            int years = int.Parse(Console.ReadLine() ?? "0");

            MortgageEngine engine = new MortgageEngine();
            engine.GenerateReport(amount, rate, years);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numbers for loan details.");
        }
    }
}