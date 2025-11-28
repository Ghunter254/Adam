//time for me to kill myself so bad bro.

//This needs three classes. 

//One class contains the object data, which will be ClientData
//One calss contains the methods, which will be ReportEngine
//One class runs the actual stuff lowkey. 
namespace Exercises;

class ClientData
{
    //Adding my fields and all that good yummy stuff
    public string ClientName;
    public double PrincipalAmount;
    public double InterestRate;
    public int YearsToGrow;

    public ClientData(string clientname, double principalAmount, double interestRate, int yearsToGrow)
    {
        ClientName = clientname;
        PrincipalAmount = principalAmount;
        InterestRate = interestRate;
        YearsToGrow = yearsToGrow;
    }
}


class ClientEngine
{
    public void GenerateReport(ClientData client)
    {
        double currentBalance = client.PrincipalAmount;
        
        for (int i = 1; i <= client.YearsToGrow; i++) 
        {
            double interestEarned = currentBalance * client.InterestRate;
            currentBalance = currentBalance + interestEarned;


            // I am guessing that the N thingie can be modified to whatever number of decimal points you want.
            Console.WriteLine($"Year {i}: +${interestEarned.ToString("N2")} Interest | New Balance: ${currentBalance:N2}");
        }
    }
}

class Program
{
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
            ClientData data = new(name, amount, rate, years);
            ClientEngine engine = new();
            engine.GenerateReport(data);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numbers.");
        }
    }
}