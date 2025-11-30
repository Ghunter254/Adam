namespace Exercises;

class TimeMachine
{
    public int CurrentYear;
    public int Energy;
    public bool IsCalibrated;
    public int Destination;

    public TimeMachine()
    //This is to fix an error. It allows for me to use a simple Run method.
    //This is a parameterless constructor. What is inside will be overriden later.
    {
        CurrentYear = 0;
        Energy = 0;
        Destination = 0;
        IsCalibrated = false;
    }
    public TimeMachine(int currentYear, int energy, bool isCalibrated, int destination)
    {
        CurrentYear = currentYear;
        Energy = energy;
        IsCalibrated = isCalibrated;
        Destination = destination;
    }
}

//For this thingie, I want to have a class that manipulates each loop.

class MachineCalibration
//this will have the first loop for calibration
{
    //this first method will calibrate the machine with energy. 
    public bool Stabilization(TimeMachine timeMachine)
    {
        int storedEnergy = timeMachine.Energy;

        while(storedEnergy < 100)
        {
            try
            {
                Console.WriteLine("Add or Remove Chrono Crystals?");
                string stabilizerModifier = Console.ReadLine().Trim().ToUpper()?? string.Empty;
                    if (stabilizerModifier == "ADD")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Chrono Crystal Added to Capacitor Bank.");
                        Thread.Sleep(500);
                        Console.WriteLine("+20 Energy Added to Capacitor");
                        storedEnergy = storedEnergy + 20;
                        Console.ResetColor();
                        Console.WriteLine("------------------------------------------------");

                    }
                    else if(stabilizerModifier == "REMOVE" && storedEnergy >= 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Chrono Crystal Removed from Capacitor Bank.");
                        Thread.Sleep(500);
                        Console.WriteLine("-10 Energy Removed from Capacitor");
                        Console.ResetColor();
                        storedEnergy = storedEnergy - 10;
                        Console.WriteLine("------------------------------------------------");
                    }
                    else if(stabilizerModifier == "REMOVE" && storedEnergy < 10)
                    {
                        Console.ForegroundColor= ConsoleColor.DarkMagenta;
                        Console.WriteLine("Not enough Energy in Capacitor Bank to carry out operation.");
                        Console.ResetColor();
                    }
            // Applying the Clamp here but I am not particularly sure if it dos anything.
            storedEnergy = Math.Clamp(storedEnergy, 0, 100);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(500);
            Console.WriteLine($"Current Energy in Capacitor = {storedEnergy}");
            Console.ResetColor();
            }
            catch(FormatException)
            {
                Console.WriteLine("You have entered an inaccurate input. Terminating program");
                return timeMachine.IsCalibrated = false;
            }
        }
    Console.WriteLine("Capacitor Bank is fully Charged.");
    return  timeMachine.IsCalibrated = true;
    }
}

class TimeEvents
{
    public static bool TemporalEvents(TimeMachine timeMachine)
    {
        Random value = new Random();
        int eventModifier = value.Next(0,11);

        if (eventModifier == 0 || eventModifier == 10 || eventModifier == 7 || eventModifier == 9 )
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Stable Cruise, regular discharge per temporal saccade initiated.");
            timeMachine.Energy = timeMachine.Energy + 3;
        }
        else if (eventModifier == 1 || eventModifier == 2 || eventModifier == 3)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Temporal Anomaly detected, increased energy required for bypass.");
            timeMachine.Energy = timeMachine.Energy - 10;
        }
        else if(eventModifier == 4 || eventModifier == 5 || eventModifier ==6 || eventModifier == 8)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Gravitational Assist incurred, decreased energy required for temporal saccade.");
            timeMachine.Energy = timeMachine.Energy + 10;
        }
        if (timeMachine.Energy == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Catastrophic Failure with Capacitor Bank! Temporal Saccade interrupted!");
            Console.ResetColor();
            return false;
        }
        Console.ResetColor();
        Console.WriteLine($"Remaining Energy in Capacitor = {timeMachine.Energy}");
        return true;

    }
}

class MachineJourney
{
    //This method first needs to find out whether the number is negative or positive
    public void machineJourney(TimeMachine timeJourney)
    {
        int startYear = timeJourney.CurrentYear;
        int endYear = timeJourney.Destination;

        try
        {
            Console.WriteLine($"What is the current Year?");
            startYear = int.Parse(Console.ReadLine()?? string.Empty);

            Console.WriteLine($"What is the destination Year?");
            endYear = int.Parse(Console.ReadLine()?? string.Empty);
            
            Console.WriteLine("----------------------------------------");
            Thread.Sleep(300);
            Console.WriteLine($"Current Year locked in as {startYear}!");
            Thread.Sleep(300);
            Console.WriteLine($"Destination Year locked in as {endYear}!");
            Thread.Sleep(300);
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine($"Initializing Temporal Jump!!");
            Thread.Sleep(300);
            
            if (startYear < endYear)
            {
                Console.WriteLine("Opening Positive Temporal Portal!");
                for(int i = startYear; i <= endYear; i++)
                {
                    Console.WriteLine($"Temporal Saccade for year {i}");
                    Console.WriteLine("-------------------------------");
                    TimeEvents.TemporalEvents(timeJourney);                 
                    Thread.Sleep(5000);              
                }
            }
            else if (startYear > endYear)
            {
                Console.WriteLine("Opening Negative Temporal Portal!");
                for(int i = startYear; i >= endYear; i--)
                {
                    Console.WriteLine($"Temporal Saccade for year {i}");
                    Console.WriteLine("-------------------------------");
                    TimeEvents.TemporalEvents(timeJourney);
                    Thread.Sleep(5000);            
                }
            }
            else if (startYear == endYear)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Warning! Temporal Saccade in the same year is not available!!");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter appropriate time coordinates");
        }
    } 
}
class Trip
{
    public static void Run()
    {
        Console.WriteLine("====TEMPORAL NAVIGATION CONSOLE OVERVIEW");
        //First setting up the TimeMachine Instance
        TimeMachine pilot = new TimeMachine();

        //Now to calibrate the machine with User Input
        MachineCalibration calibration = new MachineCalibration(); // Instantiating the Class
        bool calibrated = calibration.Stabilization(pilot);        // Using the stabilization method to pass the calibration value
        if (calibrated == false)
        {
            //Making it stop if the machine isn't calibrated
            Console.WriteLine("Failed to charge Capacitor Banks.");
            return;
        }

        //Now to run the loop that actually does the fucking journey
        MachineJourney journey = new MachineJourney();
        journey.machineJourney(pilot);

        //Fuckass exit message
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Temporal Journey Complete. Remaining Energy = {pilot.Energy}");
        Console.ResetColor();
    }
    


}

