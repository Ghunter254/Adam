namespace Lessons;

//  We use a for loop when we know exactly how many times we need to repeat something.
// Scenario: 
//    A bank client wants to invest money. They want to see a year-by-year 
//    breakdown of how their money grows.
public class InvestmentTool
{
    // Fields
    public string ClientName;
    public double PrincipalAmount; // Starting money
    public double InterestRate;    // e.g., 0.05 for 5%
    public int YearsToGrow;        // How many times to loop

    // Constructor
    public InvestmentTool(string name, double amount, double rate, int years)
    {
        ClientName = name;
        PrincipalAmount = amount;
        InterestRate = rate;
        YearsToGrow = years;
    }

    // INSTANCE METHOD: The For Loop Logic
    public void GenerateReport()
    {
        Console.WriteLine($"\n--- INVESTMENT REPORT FOR {ClientName.ToUpper()} ---");
        Console.WriteLine($"Starting Balance: ${PrincipalAmount}");
        Console.WriteLine($"Interest Rate: {InterestRate * 100}%");
        Console.WriteLine("------------------------------------------------");

        double currentBalance = PrincipalAmount;

        // THE FOR LOOP
        // Structure: for (Initializer; Condition; Iterator)
        // 1. int i = 1      -> Start counting at Year 1
        // 2. i <= YearsToGrow -> Keep going as long as 'i' is less than or equal to the target
        // 3. i++            -> After every loop, increase 'i' by 1
        
        for (int i = 1; i <= YearsToGrow; i++) 
        {
            // The Logic inside the loop happens EVERY year
            double interestEarned = currentBalance * InterestRate;
            currentBalance = currentBalance + interestEarned;
            // currentBalance += interestEarned;


            // Using "N2" to format as a number with 2 decimals
            Console.WriteLine($"Year {i}: +${interestEarned.ToString("N2")} Interest | New Balance: ${currentBalance:N2}");
        }

        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("End of Projection.\n");
    }

    // STATIC METHOD: Handling Input
    public static void Run()
    {
        try 
        {
            Console.WriteLine("Enter Client Name:");
            string name = Console.ReadLine() ?? "Unknown";

            Console.WriteLine("Enter Amount to Invest:");
            double amount = double.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Enter Interest Rate (e.g. 0.05 for 5%):");
            double rate = double.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("How many years should we project?");
            int years = int.Parse(Console.ReadLine() ?? "0");

            // Create Object
            InvestmentTool tool = new(name, amount, rate, years);
            
            // Trigger the Loop
            tool.GenerateReport();
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numbers.");
        }
    }
}