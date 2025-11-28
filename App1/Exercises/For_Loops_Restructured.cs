//time for me to kill myself so bad bro.

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

