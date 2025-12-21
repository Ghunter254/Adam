//lowkirkuenly this assignment looks easy but it might just make me kill myself, fuck everyone and everything
namespace Exercises;

class ListUtils
{//How am I going to design these fuckass methods
    public static List<string> RemoveIndexSafe(List<string> datalist, int index)
    {
        List<string> datalistRemove = new List<string>();

        if(index >= 0 && index <= datalist.Count()-1)
        {
            for(int i = 0; i < datalist.Count; i++)
            {
                if(i != index)
                {
                    datalistRemove.Add(datalist[i]);
                }
            }
            Console.WriteLine($"[Success]; Removed {datalist[index]} from index {index}");
        }
        else
        {
            Console.WriteLine($"[Error]; index {index} is out of range");
        }
        return datalistRemove;
    }   
    public static List<string> SwapItems(List<string> datalist, int indexA, int indexB)
    {
        List<string> datalistSwap = new List<string>(); 

        if(indexA >= 0 && indexA <= datalist.Count()-1 && indexB >= 0 && indexB <= datalist.Count()-1)
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
        int j = 0;
        int repeatno = 0;
        for(int i = 0; i < datalist.Count; i++)
        {//This first loop loops through the list
            while(j < datalist.Count)
            {//this loops through everything else in the list and compares it
                if(datalist[j] == datalist[i])
                {
                    repeatno++;
                }
                j++;
            }
            if (repeatno > 0)
            {
                datalistPurge.Add(datalist[i]);
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
        List<string> datalist = ["Milk", "Eggs", "Milk", "Bread", "Milk", "Cheese"];
        foreach (string item in datalist)
        {
            Console.WriteLine($"{item}");
        }
        // Safe Remove Test
        ListUtils.RemoveIndexSafe(datalist, 100);
        ListUtils.RemoveIndexSafe(datalist, 1);
        foreach (string item in datalist)
        {
            Console.WriteLine($"{item}");
        }
        // Replace Test
        ListUtils.ReplaceAll(datalist, "Milk", "Yoghurt");
        foreach (string item in datalist)
        {
            Console.WriteLine($"{item}");
        }
        // Swap Test
        ListUtils.SwapItems(datalist, 1, 2);
        foreach (string item in datalist)
        {
            Console.WriteLine($"{item}");
        }
        datalist = ["Milk", "Eggs", "Milk", "Bread", "Milk", "Cheese"];

        //5. Purge Test
        ListUtils.PurgeDuplicates(datalist);
        foreach (string item in datalist)
        {
            Console.WriteLine("FINAL LIST");
            Console.WriteLine($"{item}");
        }
    }
}