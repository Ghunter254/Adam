using System.Security.Cryptography.X509Certificates;

namespace Assignments;


class Shipment
{ //This class is probably where I want to store all the user input.

    public string destination;
    public int cargoWeight;
    public string cargoType;
    
    //our constructor
    public Shipment(string destination, int cargoWeight, string cargoType)
    {
        this.destination = destination;
        this.cargoWeight = cargoWeight; 
        this.cargoType = cargoType; 
    }
    public double distanceCoeff()
    { //I am going to fucking kill myself I've been staring at my laptop for hours
      //cost = distance coefficient*100 + (Cargo weight*10 + extra cargo fee)*cargo type + interstellar modifier
      
      double distanceCoeff = this.destination switch
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
            _ => 0.00
      };
      return distanceCoeff;

    public int baseCargoFee()
    {
        if (this.cargoWeightCentauri <= 500 && this.cargoWeight != 0)
        {
            return this.cargoWeight*10;
            
        }
        else if(this.cargoWeight > 500 && this.cargoWeight != 0)
        {
            Console.WriteLine("Since your entered weight exceeds 500 tons, we add a double surcharge for every ton above 500");
            int excessWeight = this.cargoWeight - 500;
            return this.cargoWeight*10 + excessWeight*50;
        }
        else
        {
            Console.WriteLine("Enter an actual weight dumbass");
            return 0;
        }
    }
    public double cargoModifier()
    {
        double cargoModifier = this.cargoType switch
        {
            "Regular" => 1.0,
            "Fragile" => 1.5,
            "Extra Fragile" => 4,
            "Liquid" => 6,
            "Gas" => 6.5,
            _ => 0.0,
        };
        return cargoModifier;
    }

    public int interstellarModifier()
    {
        if (distanceCoeff > 10.26)
        {
            Console.WriteLine("Your Destination is interstellar. The use of the Alcubierre Drive incurs an increase in cost");
            int interstellarCost = 1000;
            return interstellarCost;
        }
    }



       
      



      
        

    }
    public static Shipment createShipment()
    {//making the shipment object
        try
        {
            Console.WriteLine("Welcome to Event Horizon Logistics and Solutions, where we take your dreams to the stars!!");

            Console.WriteLine("Where are we headed today?");
            string endpoint = Console.ReadLine()?? string.Empty;

            Console.WriteLine("Great! How much cargo are we carrying?(in tons)");
            int cargoMass = int.Parse(Console.ReadLine()?? string.Empty);

            Console.WriteLine("Finally, what sort of cargo are we hauling?");
            Console.WriteLine("Regular, Fragile, Extra Fragile, Liquid or Gas?");
            string cargoSort = Console.ReadLine()?? string.Empty;

            return new Shipment(endpoint, cargoMass, cargoSort);
        }
        catch(FormatException)
        {
            Console.WriteLine("Enter the proper phrases");
            return new Shipment("", 0 ,"");
        }
    }
   
}
class QuoteEngine
{//Handling the logic here.
    public static void Run()
    {



    }

    
}

