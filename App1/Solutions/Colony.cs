namespace MarsColony;

public class ResourceManager
{   

    private const int MAX_CAPACITY = 100;
    private const int CRITICAL_LEVEL = 20;

    private int _oxygen;
    private int _water;
    private int _energy;
    private int _food;

    public int Oxygen
    {
        get => _oxygen;
        set
        {
            _oxygen = ClampValue(value);
            CheckCriticalLevels("Oxygen", _oxygen);
        }
    }

    public int Water
    {
        get => _water;
        set
        {
            _water = ClampValue(value);
            CheckCriticalLevels("Water", _water);
        }
    }

    public int Energy
    {
        get => _energy;
        set
        {
            _energy = ClampValue(value);
            CheckCriticalLevels("Energy", _energy);
        }
    }

    public int Food
    {
        get => _food;
        set
        {
            _food = ClampValue(value);
            CheckCriticalLevels("Food", _food);
        }
    }

    public ResourceManager(){}

    private int ClampValue(int value)
    {
        if (value < 0)
            return 0;
        if (value > MAX_CAPACITY)
            return MAX_CAPACITY;
        return value;
    }

    private void CheckCriticalLevels(string name, int value)
    {
        if (value < CRITICAL_LEVEL && value > 0)
        {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ALERT] {name} is critical ({value}%)!");
                Console.ResetColor();
        }
        else if (value == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"[DANGER] {name} DEPLETED!");
                Console.ResetColor();
            }
    }
}

public enum BuildingType
{
    Empty,
    SolarPanel,
    Greenhouse,
    WaterExtractor,
    Habitat,
    OxygenGenerator,
}

public class InfrastructureManager
{
    private BuildingType[,] _grid = new BuildingType[4,4];

    public InfrastructureManager()
    {
        // Initialize all sectors to Empty
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                _grid[i, j] = BuildingType.Empty;
            }
        }

        // Setup initial buildings
        _grid[0, 0] = BuildingType.SolarPanel;
        _grid[1, 0] = BuildingType.WaterExtractor;
        _grid[0, 1] = BuildingType.Greenhouse;
        _grid[1, 1] = BuildingType.OxygenGenerator;
    }

    public void GenerateResources(ResourceManager bank)
    {

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                switch (_grid[i, j])
                {
                    case BuildingType.SolarPanel:
                        bank.Energy += 10;
                        break;
                    case BuildingType.Greenhouse:
                        if (bank.Water >= 5)
                        {
                            bank.Water -= 5;
                            bank.Food += 10;
                            Console.WriteLine($"[loc {i},{j}] Greenhouse: -5 Water / +10 Food");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"[loc {i},{j}] Greenhouse: Production Halted (No Water!)");
                            Console.ResetColor(); 
                        }
                        break;
                    case BuildingType.WaterExtractor:
                        bank.Water += 15;
                        Console.WriteLine($"[loc {i},{j}] Water Extractor: +15 Water");
                        break;
                    case BuildingType.OxygenGenerator:
                        if (bank.Energy >= 5)
                        {
                            bank.Energy -= 5;
                            bank.Oxygen += 10;
                            Console.WriteLine($"[loc {i},{j}] Oxygen Generator: -5 Energy / +10 Oxygen");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"[loc {i},{j}] Oxygen Generator: Production Halted (No Energy!)");
                            Console.ResetColor(); 
                        }
                        break;
                }
            }
        }
        
    }
}

public class Colonist
{
    public string Name { get; set; }
    public string Job { get; set; }
    public int Health { get; set; }

    public bool IsAlive => Health > 0;

    public Colonist(string name, string job)
    {
        Name = name;
        Job = job;
        Health = 100;
    }
}

public class PopulationManager
{
    private List<Colonist> _colonists = new List<Colonist>();
    List<Colonist> _deceased = new List<Colonist>();

    private static Random _rng = new Random();

    private string[] _names =
    [
        "Alex", "Blake", "Casey", "Drew", "Elliot",
        "Finley", "Gray", "Harper", "Jordan", "Kendall",
        "Logan", "Morgan", "Parker", "Quinn", "Riley",
        "Sawyer", "Taylor", "Val", "Winter", "Zion"
    ];

    private string[] _jobs = [
        "Engineer", "Botanist",  "Miner", "Medic",
    ];

    public PopulationManager()
    {
        // Initial population
        _colonists.Add(new Colonist("Alice", "Engineer"));
        _colonists.Add(new Colonist("Bob", "Biologist"));
        _colonists.Add(new Colonist("Charlie", "Technician"));
    }

    public void AddNewColonist()
    {
        string name = _names[_rng.Next(_names.Length)];
        string job = _jobs[_rng.Next(_jobs.Length)];
        _colonists.Add(new Colonist(name, job));
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"[BIRTH] Welcome {name} the {job} to the colony.");
        Console.ResetColor();

    }

    public void ManagePopulation(ResourceManager bank)
    {
        

        foreach (Colonist colonist in _colonists)
        {   
            // Consume Food.
            if (bank.Food > 0 )
            {
                bank.Food -= 1;
                if (colonist.Health < 100)
                {
                    colonist.Health += 5; 
                }
            }
            else
            {
                colonist.Health -= 10;
                Console.WriteLine($"{colonist.Name} is starving (-10 HP)");
            }

            //  Consume Water.
            if (bank.Water > 0)
            {
                bank.Water -= 1;
            }
            else
            {
                colonist.Health -= 20;
                Console.WriteLine($"{colonist.Name} is dehydrated (-20 HP)");
            }

            // Consume Oxygen.
            if (bank.Oxygen > 0)
            {
                bank.Oxygen -= 1;
            }
            else
            {
                colonist.Health -= 30;
                Console.WriteLine($"{colonist.Name} is suffocating (-30 HP)");
            }

            if (!colonist.IsAlive)
            {
                _deceased.Add(colonist);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[DECEASED] {colonist.Name} has died.");
                Console.ResetColor();
            }
        }
        
    }

    public void RemoveDeceased()
    {   
        foreach (Colonist dead in _deceased)
        {
            _colonists.Remove(dead);
        }
        _deceased.Clear();
    }
    
    public List<Colonist> GetColonists()
    {
        return _colonists;
    }

    public bool IsPopulationAlive => _colonists.Count > 0;
    public int PopulationCount => _colonists.Count;

}

public static class EventManager
{
    private static Random _rng = new Random();

    public static void TriggerRandomEvent(PopulationManager population, ResourceManager bank)
    {
        int eventRoll = _rng.Next(1, 101);

        if (eventRoll <= 60) // 60% chance
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("No significant events today. The colony is stable.");
            Console.ResetColor();
            return;
        }
        if (eventRoll <= 80) // 20% chance
        {
            Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("EVENT: Supply Crate Found!");
                // Add a random resource
                bank.Food += 10;
                bank.Water += 10;
                Console.WriteLine("+10 Food, +10 Water added to reserves.");
                Console.ResetColor();
        }
        else if (eventRoll <= 90) // 10% chance
        {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("EVENT: Storage Leak!");
                // Lose resources
                bank.Water -= 15;
                Console.WriteLine("-15 Water lost due to a cracked pipe.");
                Console.ResetColor();
        }
        else if (eventRoll <= 95) // 5% chance
        {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("EVENT: A Miracle! A new child is born.");
                Console.ResetColor();
                
                // Call the method we wrote in PopulationManager!
                population.AddNewColonist();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("EVENT: ALIEN PLAGUE!");
                Console.WriteLine("Everyone takes 15 damage.");
                Console.ResetColor();

                // Loop through the list (via the manager) and hurt them
                foreach (Colonist c in population.GetColonists())
                {
                    if (c.IsAlive)
                    {
                        c.Health -= 15;
                    }
                }
        }
    }
}

public static class ReportManager
    {
        public static void PrintDailyReport(int day, ResourceManager resources, PopulationManager pop)
        {
            Console.WriteLine("\n=============================================");
            Console.WriteLine($"           DAILY REPORT: SOL {day}");
            Console.WriteLine("=============================================");

            // Smart logic to give a one-word summary of how we are doing.
            string status = "STABLE";
            ConsoleColor statusColor = ConsoleColor.Green;

            if (pop.PopulationCount == 0)
            {
                status = "GHOST TOWN";
                statusColor = ConsoleColor.DarkGray;
            }
            else if (resources.Oxygen < 20 || resources.Water < 20 || resources.Food < 20)
            {
                status = "CRITICAL";
                statusColor = ConsoleColor.Red;
            }
            else if (pop.PopulationCount > 5 && resources.Food > 80)
            {
                status = "THRIVING";
                statusColor = ConsoleColor.Cyan;
            }

            Console.Write(" STATUS: ");
            Console.ForegroundColor = statusColor;
            Console.WriteLine(status);
            Console.ResetColor();

            // RESOURCE DASHBOARD
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(" RESOURCES:");
            PrintBar(" Oxygen", resources.Oxygen);
            PrintBar(" Water ", resources.Water);
            PrintBar(" Energy", resources.Energy);
            PrintBar(" Food  ", resources.Food);

            // POPULATION STATS
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($" COLONISTS: {pop.PopulationCount} Alive");
            
            // Calculate Average Health for a "Smart" metric
            int totalHealth = 0;
            foreach(var c in pop.GetColonists()) totalHealth += c.Health;
            
            int avgHealth = pop.PopulationCount > 0 ? totalHealth / pop.PopulationCount : 0;
            
            Console.Write($" AVG HEALTH: ");
            if(avgHealth < 50) Console.ForegroundColor = ConsoleColor.Red;
            else if(avgHealth < 80) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine($"{avgHealth}%");
            Console.ResetColor();
            
            Console.WriteLine("=============================================\n");
            
            // Wait for user to read it
            Console.WriteLine("Press Enter to start next day...");
            Console.ReadLine();
        }

        // Helper to draw a visual progress bar
        private static void PrintBar(string label, int value)
        {
            Console.Write($"{label}: [");
            
            // Draw 10 blocks (1 block = 10%)
            int blocks = value / 10;
            
            if (value < 30) Console.ForegroundColor = ConsoleColor.Red;
            else if (value > 80) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < 10; i++)
            {
                if (i < blocks) Console.Write("█");
                else Console.Write("-");
            }
            Console.ResetColor();
            Console.WriteLine($"] {value}/100");
        }

}

public class Simulation
{
    private ResourceManager _resourceManager;
    private InfrastructureManager _infrastructureManager;
    private PopulationManager _populationManager;

    public Simulation()
    {
        _resourceManager = new ResourceManager
        {
            Oxygen = 50,
            Water = 50,
            Energy = 50,
            Food = 50
        };

        _infrastructureManager = new InfrastructureManager();

        // Setup initial buildings
        _infrastructureManager.GenerateResources(_resourceManager); // Initial generation to reflect buildings

        _populationManager = new PopulationManager();
    }

    public void Run(int totalDays)
    {
        Console.Clear();
        Console.WriteLine("Welcome to Project Exodus. Initializing Mars Colony...");
        Thread.Sleep(2000);

        for (int day = 1; day <= totalDays; day++)
        {
            Console.Clear();
            Console.WriteLine($"--- SOL {day} ---");
            Thread.Sleep(1000);

            // PRODUCTION PHASE
            _infrastructureManager.GenerateResources(_resourceManager);
            Thread.Sleep(500);

            // CONSUMPTION PHASE
            _populationManager.ManagePopulation(_resourceManager);
            Thread.Sleep(500);

            // EVENT PHASE
            EventManager.TriggerRandomEvent(_populationManager, _resourceManager);
            Thread.Sleep(500);
            
            _populationManager.RemoveDeceased();

            // Check for colony survival
            if (!_populationManager.IsPopulationAlive)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("All colonists have perished. The colony has failed.");
                Console.ResetColor();
                break;
            }

            // REPORT PHASE
            ReportManager.PrintDailyReport(day, _resourceManager, _populationManager);

        }
        Console.WriteLine("Simulation Complete.");
    }
}

public class Program
{
    public static void RunSimulation()
    {
        Simulation simulation = new Simulation();
        simulation.Run(30);
    }
}