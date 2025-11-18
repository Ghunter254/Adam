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
    public Shipment 
}

