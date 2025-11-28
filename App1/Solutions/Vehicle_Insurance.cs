namespace Assignments;

public class Applicant
{
    public string name;
    public int age;
    public string vehicleType;
    public int yearsDriving;

    public Applicant(string appName, int appAge, string vehicle, int drivingExperience)
    {
        //No need to use this since he gave me unique identifiers and shi
        name = appName;
        age = appAge;
        vehicleType = vehicle;
        yearsDriving = drivingExperience;
    }
    public double CalculateBasePremium()
    { 
        //using the fancy switch because it is elegant
        double basePremium = vehicleType switch
        {
            "Sedan" => 1000.0,
            "SUV" => 1200.0,
            "Sport" => 1800.0,
            _ => 1400.0 //this is the default case, usually it looks like "_" but his looks cooler so I am using that instead
        };
        return basePremium;
    }
    public double CalculateRiskFactor()
    {
        if (age < 25 || yearsDriving < 2)
        {
            return 1.8; //High Risk
        }
        else if(age >= 25 && yearsDriving < 2)
        {
            return 1.2; //Medium Risk
        }
        else
        {
            return 1.0; //Low Risk
        }
    }
    public void DisplayQuote()
    { //Remember to ask Yona about the variable names
        double basePremium = CalculateBasePremium();
        double riskFactor = CalculateRiskFactor();
        double finalQuote = basePremium*riskFactor;
        
        string policyType = (riskFactor > 1.5) ? "High-Risk Policy" : "Standard Policy";

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Vehicle Type: {vehicleType}");
        Console.WriteLine($"Base Premium: {basePremium}");
        Console.WriteLine($"Risk Factor: {riskFactor}");
        Console.WriteLine($"Policy Type: {finalQuote}"); //Remember to come back and format this nicely
    }
    public static Applicant  RequestApplicantData()
    {
        try
        {
            Console.WriteLine("Enter your name lowkey");
            string applicantName = Console.ReadLine()?? string.Empty; //Parse things correctly bro

            Console.WriteLine("Enter your age lowkey");
            int applicantAge = int.Parse(Console.ReadLine()?? string.Empty);

            Console.WriteLine("Enter your vehicle type lowkey(Sedan, SUV, Sport)");
            string applicantVehicle = Console.ReadLine()?? string.Empty;

            Console.WriteLine("Enter your driving years lowkey");
            int applicantYears = int.Parse(Console.ReadLine()?? string.Empty);

            return new Applicant(applicantName, applicantAge, applicantVehicle, applicantYears);
        }
        catch(FormatException)
        {   
            Console.WriteLine("Enter valid shi");
            return new Applicant("_",25,"_",5);
        }
    }
    public static void Run()
    {
        
        Applicant broski = Applicant.RequestApplicantData();
        broski.DisplayQuote();
    }    
}