namespace Exercises;

class LoanApplicant
{
    public double Income;
    public double Debt;
    public bool IsQualified;
    
    public LoanApplicant(int income, int debt, bool isQualified)
    {
        Income = income;
        Debt = debt;
        IsQualified = isQualified;
    }
    public double CalculateDTI()
    {//DTI = (Total Monthly Debts / Total Monthly Income) * 100.
        try
        {
             double dti = Debt/Income * 100;
            return dti;
        }
        catch(DivideByZeroException)
        {
            Console.WriteLine("One of the numbers you entered is zero lmao, shi won't work");
            return 0;
        }
        catch(FormatException)
        {
            Console.WriteLine("Enter proper Digits my dude");
            return 0;
        }
    }
}

class QualificationEngine
{
    //We will use this class as specified in the readme


    public bool RunQualification(LoanApplicant loanApplicant)
    {//We want this while loop to only break when the results are positive
        while(!loanApplicant.IsQualified)
        {
            try
            {
                Console.WriteLine("What is your Monthly Income?");
                loanApplicant.Income = double.Parse(Console.ReadLine()??string.Empty);

                Console.WriteLine("What is your Monthly Debt?");
                loanApplicant.Debt = double.Parse(Console.ReadLine()??string.Empty);

                Console.WriteLine("Calculating DTI.......");
                Thread.Sleep(2000);

                double loanDTI=loanApplicant.CalculateDTI();
                if(loanDTI > 43 && loanDTI <= 100 && loanDTI >= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Your current DTI of {loanDTI}% is above 43%. We cannot offer you a loan at this time");
                    Console.ResetColor();
                }
                else if(loanDTI < 43 && loanDTI >= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your current DTI of {loanDTI}% is below 43%. APPROVED!");
                    Console.ResetColor();
                    return loanApplicant.IsQualified = true;
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Enter proper values my brother");
                return false;
            }
        }
    return loanApplicant.IsQualified;
    }
}

class Amortization
{// this class obtains the loan data i.e loan amount, interest rate and loan term in years.
    public double loanAmount;
    public double interestRate;
    public int loanPeriod;

    public Amortization(double loanAmount, double interestRate, int loanPeriod)
    {
       this.loanAmount = loanAmount;
       this.interestRate = interestRate;
       this.loanPeriod = loanPeriod;
    }
    public static Amortization RequestLoanData()
    {
        try
        {
            Console.WriteLine("How large of a loan would you like?");
            double loanAmount = double.Parse(Console.ReadLine()??string.Empty);
            
            Console.WriteLine("What is your desired interest rate per year?");
            double interestRate = double.Parse(Console.ReadLine()??string.Empty);
            
            Console.WriteLine("How long is your loan period in years?");
            int loanPeriod = int.Parse(Console.ReadLine()??string.Empty);

            return new(loanAmount, interestRate, loanPeriod);
        }
        catch(FormatException)
        {
            Console.WriteLine("Enter appropriately formatted information kindly");
            return RequestLoanData();
        }
    }
}

class MortgageEngine
{   //First function is for gooning the math and shi
    //Formula: M = P * ( r * (1+r)^n ) / ( (1+r)^n - 1 )
    //P = Loan Amount
    //r = Monthly Interest Rate (Annual Rate / 100 / 12)
    //n = Total Months (Years * 12)
    //(Use Math.Pow for the ^ part).
    Amortization mortgadeData = Amortization.RequestLoanData();
    public double CalculateMortgage() 
    {
        double principal = mortgadeData.loanAmount; //P
        double monthlyInterest= mortgadeData.interestRate/100/12; // r
        int  totalMonths = mortgadeData.loanPeriod*12; // n
        //I fucking hate the exponent method
        double base1 = 1 + monthlyInterest;
        double exponent1 = totalMonths;
        double monthlyPayment = principal*(monthlyInterest * Math.Pow(base1,exponent1))/(Math.Pow(base1,exponent1)-1);
        return monthlyPayment;
    }
    public void GenerateReport()
    {//This fuckass function generates the report lowkey
//THE LOOP (The Schedule):
//Create a FOR loop that runs from month 1 to month n.
//Inside the loop, for every month:
//1. Calculate Interest Payment = Current Balance * r.
//2. Calculate Principal Payment = Total Monthly Payment - Interest Payment.
//3. Update Current Balance = Current Balance - Principal Payment.
//4. Print the row: "Month X | Payment: $... | Principal: $... | Interest: $... | Balance: $..."
        Console.WriteLine("-----REPAYMENT SCHEDULE-----");

        double currentBalance = mortgadeData.loanAmount;
        int months = mortgadeData.loanPeriod*12;
        double payment = CalculateMortgage();

        for(int i = 1; i == months; i++)
        {
            double interestPayment = currentBalance*mortgadeData.interestRate;
            double principalPayment = payment*interestPayment;
            currentBalance = currentBalance - principalPayment;
            Console.WriteLine($"Month {i}   | Payment: {principalPayment:C} | Principal: {}  | Interest: {interestPayment:C} | Balance: {currentBalance:C}")
        }
    }
}

