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

class QualificationEngine()
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
                    Console.WriteLine($"Your current DTI of {loanDTI} is above 43%. We cannot offer you a loan at this time");
                    Console.ResetColor();
                }
                else if(loanDTI < 43 && loanDTI >= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your current DTI of {loanDTI} is below 43%. APPROVED!");
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

class Amortization()
{// this class handles the loan request.
    public 
    
}

