namespace Solutions;

public class Shipment
{
    // Properties are better than public fields (Standard C# practice)
    public string Destination { get; set; }
    public int CargoWeight { get; set; }
    public string CargoType { get; set; }

    public Shipment(string destination, int cargoWeight, string cargoType)
    {
        Destination = destination;
        CargoWeight = cargoWeight;
        CargoType = cargoType;
    }
}

public class QuoteEngine
{
    // 1. Calculate Distance Coefficient
    // Notice: We pass the 'Shipment' object IN so we can look at its data.
    public double CalculateDistanceCoeff(Shipment shipment)
    {
        return shipment.Destination switch
        {
            "Moon" => 5.58,
            "Mercury" => 8.17,
            "Mars" => 8.36,
            "Phobos" => 8.36,
            "Deimos" => 8.36,
            "Jupiter" => 8.89,
            "Europa" => 8.89,
            "Io" => 8.89,
            "Ganymede" => 8.89,
            "Saturn" => 9.15,
            "Titan" => 9.15,
            "Enceladus" => 9.15,
            "Uranus" => 9.46,
            "Neptune" => 9.65,
            "Proxima_B" => 13.64,
            _ => 0.00 // In a real app, we might throw an error here!
        };
    }

    // 2. Calculate Base Cargo Fee
    // CHANGE: No Console.WriteLine here. We just return the math.
    public double CalculateBaseCargoFee(Shipment shipment)
    {
        if (shipment.CargoWeight <= 0) return 0;

        if (shipment.CargoWeight <= 500)
        {
            return shipment.CargoWeight * 10;
        }
        else
        {
            // Logic: Base 500 * 10, plus excess * 50
            int excessWeight = shipment.CargoWeight - 500;
            return (500 * 10) + (excessWeight * 50);
        }
    }

    // 3. Calculate Cargo Modifier
    public double CalculateCargoModifier(Shipment shipment)
    {
        return shipment.CargoType switch
        {
            "Regular" => 1.0,
            "Fragile" => 1.5,
            "Extra Fragile" => 4.0,
            "Liquid" => 6.0,
            "Gas" => 6.5,
            _ => 1.0 // Default to 1.0 instead of 0.0 to avoid breaking multiplication
        };
    }

    // 4. Calculate Interstellar Fee
    public int CalculateInterstellarFee(Shipment shipment)
    {
        // We call our own internal method to check the distance
        double distance = CalculateDistanceCoeff(shipment);

        if (distance > 10.26)
        {
            return 1000;
        }
        return 0;
    }

    // 5. THE MASTER CALCULATION
    // This method calls all the others to get the final total.
    public  double CalculateTotalCost(Shipment shipment)
    {
        double distCoeff = CalculateDistanceCoeff(shipment);
        double baseFee = CalculateBaseCargoFee(shipment);
        double cargoMod = CalculateCargoModifier(shipment);
        int interstellarFee = CalculateInterstellarFee(shipment);

        // The Formula
        return (distCoeff * 100) + (baseFee * cargoMod) + interstellarFee;
    }
}

class Program
{
    public static void Run()
    {
        Console.WriteLine("Welcome to Event Horizon Logistics!");

        // 1. GET DATA (The UI Job)
        Shipment myShipment = GetUserShipmentData();

        // 2. PROCESS DATA (The Engine Job)
        QuoteEngine engine = new();
        
        double totalCost = engine.CalculateTotalCost(myShipment);
        double travelTime = engine.CalculateDistanceCoeff(myShipment) * engine.CalculateCargoModifier(myShipment);
        int interstellarFee = engine.CalculateInterstellarFee(myShipment);

        // 3. DISPLAY RESULTS (The UI Job)
        Console.WriteLine("\n--- QUOTE GENERATED ---");
        
        // We can create custom messages here based on the data
        if (interstellarFee > 0)
        {
            Console.WriteLine("NOTICE: Interstellar Destination. Alcubierre Drive Surcharge Applied.");
        }

        if (myShipment.CargoWeight > 500)
        {
            Console.WriteLine("NOTICE: Heavy Cargo Surcharge Applied.");
        }

        Console.WriteLine($"Destination: {myShipment.Destination}");
        Console.WriteLine($"Est. Travel Time: {travelTime:F2} years"); // :F2 formats to 2 decimal places
        Console.WriteLine($"TOTAL COST: ${totalCost:N0} million");
    }

    // Helper method to keep the main method clean
    static Shipment GetUserShipmentData()
    {
        try
        {
            Console.WriteLine("Where are we headed?");
            string dest = Console.ReadLine() ?? "";

            Console.WriteLine("Cargo Weight (tons)?");
            int weight = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Cargo Type (Regular, Fragile, Liquid, Gas)?");
            string type = Console.ReadLine() ?? "Regular";

            return new Shipment(dest, weight, type);
        }
        catch
        {
            Console.WriteLine("Invalid Input. Using Default values.");
            return new Shipment("Moon", 100, "Regular");
        }
    }
}