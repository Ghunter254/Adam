//lowkirkuenly this assignment looks easy but it might just make me kill myself, fuck everyone and everything
namespace Exercises;

class ListUtils
{//How am I going to design these fuckass methods
    public static List<string> RemoveIndexSafe(List<string> datalist, int index)
    {
        List<string> datalistRemove = new List<string>();
        if(index >= 0 && index < datalist.Count)
        {
            for(int i = 0; i < datalist.Count; i++)
            {
                if(i != index)
                {
                    datalistRemove.Add(datalist[i]);
                }
            }
            Console.WriteLine($"[Success]; Removed {datalist[index]} from index {index}");
            return datalistRemove;

        }
        else
        {
            Console.WriteLine($"[Error]; index {index} is out of range");
            return datalist;
        }
    }   
    public static List<string> SwapItems(List<string> datalist, int indexA, int indexB)
    {
        List<string> datalistSwap = new List<string>(); 

        if(indexA >= 0 && indexA <= datalist.Count-1 && indexB >= 0 && indexB <= datalist.Count-1)
        {
            string objectA = datalist[indexA];
            string objectB = datalist[indexB];

            for(int i = 0; i < datalist.Count; i++)
            {
                if (i == indexA)
                {
                    datalistSwap.Add(objectB);
                }
                else if (i == indexB)
                {
                    datalistSwap.Add(objectA);
                }
                else
                {
                    datalistSwap.Add(datalist[i]);
                }
            }
        }
        Console.WriteLine($"[Report]; Replaced index {indexA} with {indexB}");
        return datalistSwap;
    }
    public static List<string> ReplaceAll(List<string> datalist,string target, string replacement)
    {
        List<string> datalistReplace = new List<string>();
        int count = 0;

        for (int i = 0; i < datalist.Count; i++)
        {
            if(datalist[i] == target)
            {
                datalistReplace.Add(replacement);
                count++;
            }
            else
            {
                datalistReplace.Add(datalist[i]);
            }
        }
        Console.WriteLine($"[Report]; Replaced {count} instances of {target}");
        return datalistReplace;
    }
    public static List<string> PurgeDuplicates(List<string> datalist)
    {//I want to use a loop here
     //It should compare the first thing with everything else in the list
     //Then the same will be done for everything else in the thingiemajig
     //It is then placed in a new list if it has no repeats
     
        List<string> datalistPurge = new List<string>();
        
        for(int i = 0; i < datalist.Count; i++)
        {//This first loop loops through the list
            int repeatno = 0;
            for(int j = 0; j < datalist.Count; j++)
            {//this loops through everything else in the list and compares it
                if(datalist[j] == datalist[i])
                {
                    repeatno++;
                }
            }
            if (repeatno == 1)
            {
                datalistPurge.Add(datalist[i]);
                repeatno--;
            }
        }
        Console.WriteLine("[Success]; List Cleaned");
        return datalistPurge;
    }
}
class MainThree
{
    public static void Run()
    {   // Printing List
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("PRINTING ORIGINAL LIST");
        Console.ResetColor();
        List<string> datalist = ["Milk", "Eggs", "Milk", "Bread", "Milk", "Cheese"];
        foreach (string item in datalist)
        {
            Console.Write($"[{item}] ");
        }
        Console.WriteLine();

        // Safe Remove Test
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("SAFE REMOVE TEST");
        Console.ResetColor();
        datalist = ListUtils.RemoveIndexSafe(datalist, 100);
        datalist = ListUtils.RemoveIndexSafe(datalist, 2);
        foreach (string item in datalist)
        {
            Console.Write($"[{item}] ");
        }
        Console.WriteLine();

        // Replace Test
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("REPLACE TEST");
        Console.ResetColor();
        datalist = ListUtils.ReplaceAll(datalist, "Milk", "Yoghurt");
        foreach (string item in datalist)
        {
            Console.Write($"[{item}] ");
        }
        Console.WriteLine();

        // Swap Test
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("SWAP TEST");
        Console.ResetColor();
        datalist = ListUtils.SwapItems(datalist, 1, 2);
        foreach (string item in datalist)
        {
            Console.Write($"[{item}] ");
        }
        Console.WriteLine();

        datalist = ["Milk", "Eggs", "Milk", "Bread", "Milk", "Cheese"];

        //5. Purge Test
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("PURGE TEST");
        Console.ResetColor();
        datalist = ListUtils.PurgeDuplicates(datalist);
        Console.WriteLine("FINAL LIST");
        foreach (string item in datalist)
        {
            Console.Write($"[{item}] ");
        }
        Console.WriteLine();
    }
}