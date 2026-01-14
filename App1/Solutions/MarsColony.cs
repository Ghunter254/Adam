using System.Runtime.Versioning;

namespace Exercises;
//////////////////////////ARCHITECTURE//////////////////////////
class ResourceManager
{
    private int _water;
    public int Water
    {
        get {return _water;}
        set //Clamping water to 0 and 100
        {
            if(value < 0) _water = 0;
            else if (value > 100) _water = 100;
            else _water = value;
        }
    }
    private int _oxygen;
    public int Oxygen
    {
        get {return _oxygen;}
        set //Clamping oxygen to 0 and 100
        {
            if(value < 0) _oxygen = 0;
            else if (value > 100) _oxygen = 100;
            else _oxygen = value;
        }
    }
    private int _energy;
    public int Energy
    {
        get {return _energy;}
        set //Clamping energy to 0 and 100
        {
            if(value < 0) _energy = 0;
            else if (value > 100) _energy = 100;
            else _energy = value;
        }
    }
    //Low Oxygen Flag
    public bool LowOxygen => Oxygen < 20;
    //Constructor
    public ResourceManager(int water, int oxygen, int energy)
    {
        Water = water;
        Oxygen = oxygen;
        Energy = energy;
    }
}
class InfrastructureManager
{
    //Constructor

    public int populationCap;
    public int emptyNodes;
    public string [,] infraGrid;
    private readonly int rows = 4;
    private readonly int columns = 4;

    public int habDomeCount ;

    public InfrastructureManager(int populationCap, int emptyNodes, int habDomeCount)
    {

        this.populationCap = populationCap;
        this.emptyNodes = emptyNodes;
        infraGrid = new string [rows,columns];
        this.habDomeCount = 0;
    }

    string solarPanel = "SP";
    string greenHouse = "GH";
    string habDome = "HD";
    string electrolyser = "EL";
    string empty = "N/A";
    public InfrastructureManager ScanProduction(ResourceManager Resources, InfrastructureManager infrastructure)
    {
        foreach (string modules in infraGrid)
        {
            if (modules == solarPanel) Resources.Energy += 10;
            if (modules == greenHouse) Resources.Water += 10;
            if (modules == electrolyser) Resources.Oxygen += 10;
            if (modules == empty) emptyNodes++;
            if (modules == habDome)
            {
                Resources.Oxygen += 10; 
                habDomeCount++; 
            }
        }
        populationCap = habDomeCount*10;
        return new(populationCap, emptyNodes, habDomeCount);
    }   
}
class ColonistManager
{
    private string _name;
    public string Name {get; set;}
    private string _job;
    public string Job {get;set;}
    private int _health;
    public int Health
    {
        get {return _health;}
        set
        {
            if (value < 0) _health = 0;
            else if (value > 100) _health = 100;
            else {_health = value;}
        }    
    }
    public bool isAlive => Health > 0;
    //Constructor
    public ColonistManager(string Name, string Job, int Health)
    {
        this.Health = Health;
        this.Job = Job;
        this.Name = Name;
    }
    List<ColonistManager> colonists = new List<ColonistManager>();
    public void Eat(ResourceManager Resources)
    {
        foreach (ColonistManager Colonist in colonists)
        {
            if (Resources.Water > 1 && Resources.Oxygen > 1 && isAlive == true)
            {
                Resources.Water -= 1;
                Resources.Oxygen -= 1;
            }
        }
    }
    public void TakeDamage(ResourceManager Resources)
    {
        foreach (ColonistManager Colonist in colonists)
        {
            if (Resources.Water == 0 || Resources.Oxygen == 0 && isAlive == true)
            {
                Colonist.Health -= 20;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Colonist {Colonist.Name} has taken damage");
                Console.ResetColor();
            }
        }
    }
    public void TakeMildPlagueDamage()
    {
        foreach (ColonistManager Colonist in colonists)
        {
            if (isAlive == true)    Colonist.Health -= 15;
        }
    }
    public void TakeHeavyPlagueDamage()
    {
        foreach (ColonistManager Colonist in colonists)
        {
            if (isAlive == true)    Colonist.Health -= 20;
        }
    }
    public void CreateColonist()
    {
        Console.WriteLine("Create 10 new colonists by entering their names and Jobs below");
        for(int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{i} Enter Name;");
            string colonistName = Console.ReadLine()?? string.Empty;
            Console.WriteLine($"{i} Enter Job;");
            Console.WriteLine("1. Miner \n2. Engineer\n3. Miscallenous");
            string colonistJob = Console.ReadLine()?? string.Empty;
        }
    }
    public void Reproduce(ResourceManager Resources, InfrastructureManager Infrastructure)
    { 
        if(Resources.Water == 100 && Resources.Oxygen == 100 && isAlive == true && Infrastructure.populationCap > colonists.Count)
        {
            bool reproductionConfirmer = false;
            while(reproductionConfirmer == false)
            {
                try
                {
                    Random enable = new Random();
                    int reproductionModifier = enable.Next(0,2);
                    if (reproductionModifier == 1)
                    {
                        Random index1 = new Random();
                        int selectionIndex1 = index1.Next(0, colonists.Count);
                        Random index2 = new Random();
                        int seletionIndex2 = index2.Next(0,colonists.Count);

                        Console.WriteLine($"Colonist {colonists[selectionIndex1].Name} and colonist {colonists[seletionIndex2].Name} had a child!!");
                        Thread.Sleep(2000);
                        Console.WriteLine($"What would you like to name the child?");
                        string childName = Console.ReadLine()?? string.Empty;
                        Console.WriteLine($"What would you like their job to be");
                        Console.WriteLine("1. Miner \n2. Engineer\n3. Miscallenous");
                        string childJob = Console.ReadLine()?? string.Empty;

                        ColonistManager newColonist = new ColonistManager(childName, childJob, 100);
                        colonists.Add(newColonist);
                        reproductionConfirmer = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a name that is a String");
                    reproductionConfirmer = false;
                }
            }
        }
    }
    public void Die()
    {
        foreach(ColonistManager colonist in colonists)
        {//Look at this cool ass piece of code I found
         //I found a way to just remove all items in a list that don't meet a certain condition
            if (isAlive == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Colonist {colonist.Name} has died!");
                Console.ResetColor();
                Thread.Sleep(500);
            }
        }
        colonists.RemoveAll(c => isAlive == false);
    }
}
//////////////////////////SIMULATION//////////////////////////
class Events()
{
    public static void Plague(ColonistManager colonist)
    {
        Random random = new Random();
        int severity = random.Next(1,3);

        if (severity == 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"A flu outbreak has begun!");
            Console.WriteLine($"Colonists take 10 damage each");
            Console.ResetColor();
            colonist.TakeMildPlagueDamage();
        }
        if (severity == 2)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"A Covid outbreak has begun!");
            Console.WriteLine($"Colonists take 20 damage each");
            Console.ResetColor();
            colonist.TakeHeavyPlagueDamage();
        }
    }
    public static void MeteorStrike(InfrastructureManager infrastructureManager)
    {
        Random index1 = new Random();
        int row = index1.Next(0,4);
        Random index2 = new Random();
        int column = index2.Next(0,4);
        string targeted = infrastructureManager.infraGrid[row,column];

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"METEOR STRIKE at {infrastructureManager.infraGrid[row,column]} !");
        Console.WriteLine($"{targeted} has been destroyed!");
        Console.ResetColor();
        infrastructureManager.infraGrid[row,column] = "N/A";
    }
    public static void Failure(InfrastructureManager infrastructureManager, ResourceManager Resources)
    {
        Random index1 = new Random();
        int row = index1.Next(0,4);
        Random index2 = new Random();
        int column = index2.Next(0,4);

        Console.ForegroundColor = ConsoleColor.DarkRed;
        string celltype = infrastructureManager.infraGrid[row,column];
        //Piece of code that skips empty thingies
        if (string.IsNullOrEmpty(celltype)) return;
        Console.WriteLine($"Equipment failure at {celltype}");

        if (celltype == "SP")    Resources.Energy -= 10;
        if (celltype == "GH")    Resources.Water -= 10;
        if (celltype == "EL")    Resources.Oxygen -= 10;
        if (celltype == "HD")    Resources.Oxygen -= 10;
    }
    public static void EventExecutor(ColonistManager colonist, InfrastructureManager infrastructure, ResourceManager resources)
    {
        Random random = new Random();
        int enabler = random.Next(0,2);
        if(enabler == 1)
        {
            Random rand = new Random();
            int eventType = random.Next(0,3);

            if (eventType == 0)     Plague(colonist);
            if (eventType == 1)     MeteorStrike(infrastructure);
            if (eventType == 2)     Failure(infrastructure, resources);
        }
        else if (enabler == 0) return;
    }
}
class Simulator()
{// I want this class to deploy all the methods as well as run the 30 day loop with appropriate thread sleeps and shi
    public void SimulationLoop(InfrastructureManager infrastructure, ResourceManager resource, Events events, ColonistManager colonist)
    //Lowkirkuenly set da resources
    {
        ResourceManager resources = new(resource.Water, resource.Energy, resource.Oxygen);
        ColonistManager colonists = new(colonist.Name, colonist.Job, colonist.Health);

        resource.Oxygen = 50;
        resource.Energy = 50;
        resource.Water = 50;

        for(int i = 0; i <= 30; i++)
        // Run the loop for 30 days
        // First run random events function
        // Then ScanProduction to update everything
        // Then run all ColonistMethods
        {
           Console.WriteLine($"Day {i}");

            infrastructure.ScanProduction(resources, infrastructure);
            Events.EventExecutor(colonists, infrastructure, resources);

            colonists.Eat(resources);
            colonists.TakeDamage(resources);
            colonists.Die();

            Thread.Sleep(2000); 
        }
    }
}