
// LESSON: ARRAYS & MULTIDIMENSIONAL ARRAYS IN C#
//
// What You Will Learn:
// 1. What a normal (1D) array is.
// 2. How to store multiple related values using an array.
// 3. How to loop through an array (using for loops).
// 4. How to use arrays inside methods and classes.
// 5. How multidimensional arrays work (2D arrays).
// 6. Two full programs in the usual structure (Classes + Methods + Program.Run).


namespace Lessons
{
    // PART 1: 1D ARRAYS (One-Dimensional Arrays)
    //
    // Think of a 1D array as a row of lockers.
    // Each locker stores 1 value.
    //
    // Example:
    // We store the daily temperatures recorded by a classroom sensor.


    class TemperatureTracker
    {
        // This method demonstrates declaring and using a 1D array
        public void ShowTemperatures()
        {
            // A 1D array storing temperatures recorded throughout the day
            // int temp = 20;
            // int temp2 = 23;
            int[] temperatures = [ 23, 24, 22, 25, 27 ];
            Console.WriteLine("Temperature Readings (°C):");
            // Console.WriteLine("Temperature Readings (°C):" , temperature[0]);

            // Loop through the array and print each temperature
            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine($"Hour {i + 1}: {temperatures[i]}°C");
            }

            Console.WriteLine();
        }

        // Example: Calculate the average temperature
        public double CalculateAverage(int[] temps)
        {
            int sum = 0;

            for (int i = 0; i < temps.Length; i++)
            {
                sum += temps[i];
            }

            return (double)sum / temps.Length;
        }
    }



    // PART 2: 2D ARRAYS (Multidimensional Arrays)
    //
    // Think of a 2D array as a grid or table.
    // Rows and Columns → like a small spreadsheet.
    //
    // Example theme:
    // We store seat availability in a mini-theatre classroom.
    // 0 = empty seat
    // 1 = occupied seat
    //

    class SeatMap
    {
        // Show a 2D seating layout (3 rows, 4 seats each)
        public void DisplaySeats()
        {
            // 2D array representing seats
            int[,] seats = new int[3, 4]
            {
                { 1, 0, 0, 1 },
                { 0, 0, 1, 0 },
                { 1, 1, 0, 0 }
            };

            Console.WriteLine("CLASSROOM SEATING MAP (1 = Occupied, 0 = Empty):");

            // Two nested loops → one for rows, one for columns

            for (int row = 0; row < seats.GetLength(0); row++)
            {
                Console.Write($"Row {row + 1}: "); // Label the row

                for (int col = 0; col < seats.GetLength(1); col++)
                {
                    
                    // If 1, print [X] (Occupied). If 0, print [ ] (Empty).
                    string symbol = (seats[row, col] == 1) ? "[X]" : "[ ]";
                    Console.Write(symbol + " ");
                }
                Console.WriteLine();
            }
            
        }

        // Count available seats
        public int CountEmptySeats(int[,] seats)
        {
            int empty = 0;

            for (int row = 0; row < seats.GetLength(0); row++)
            {
                for (int col = 0; col < seats.GetLength(1); col++)
                {
                    if (seats[row, col] == 0)
                        empty++;
                }
            }

            return empty;
        }
    }


    // ---------------------------------------------------------
    // PART 3: FULL PROGRAM DEMO #1
    // A student will enter 5 mood levels (1–10) to track how they felt today.
    // Demonstrates:
    // - User input to fill a 1D array
    // - Method that analyzes the array
    // ---------------------------------------------------------

    class MoodTracker
    {
        public static void Run()
        {
            Console.WriteLine("=== MOOD TRACKER ===");
            Console.WriteLine("Enter your mood rating (1-10) for each of the 5 study sessions today.");

            int[] moods = new int[5];

            // moods[0] = 5;
            // bool success = false.
            // success inverted = true.
            for (int i = 0; i < moods.Length; i++)
            {
                Console.Write($"Mood for session {i + 1}: ");

                if (!int.TryParse(Console.ReadLine(), out moods[i]))
                {
                    Console.WriteLine("Invalid number! Restart program.");
                    return;
                }
            }

            int sum = 0;
            for (int i = 0; i < moods.Length; i++)
            {
                sum += moods[i];
            }

            double averageMood = (double)sum / moods.Length;
            Console.WriteLine($"\nYour average mood today was: {averageMood:F1}/10\n");
        }
    }


    // ---------------------------------------------------------
    // PART 4: FULL PROGRAM DEMO #2
    // A 2D board storing noise levels in different classroom corners.
    // Demonstrates:
    // - Declaring 2D arrays
    // - Processing them
    // ---------------------------------------------------------

    class NoiseMap
    {
        public static void Run()
        {
            int[,] noiseLevels =
            {
                { 42, 40, 38 },
                { 45, 43, 41 },
                { 39, 36, 37 }
            };

            Console.WriteLine("=== CLASSROOM NOISE MAP (dB) ===");

            // Print the noise grid
            for (int r = 0; r < noiseLevels.GetLength(0); r++)
            {
                for (int c = 0; c < noiseLevels.GetLength(1); c++)
                {
                    Console.Write(noiseLevels[r, c] + " ");
                }
                Console.WriteLine();
            }

            // Find the loudest spot
            int maxNoise = noiseLevels[0, 0];

            for (int r = 0; r < noiseLevels.GetLength(0); r++)
            {
                for (int c = 0; c < noiseLevels.GetLength(1); c++)
                {
                    if (noiseLevels[r, c] > maxNoise)
                        maxNoise = noiseLevels[r, c];
                }
            }

            Console.WriteLine($"\nLoudest area recorded: {maxNoise} dB");
        }
    }


    // ---------------------------------------------------------
    // MAIN PROGRAM SELECTOR
    // ---------------------------------------------------------

    class Arrays
    {
        public static void Run()
        {
            Console.WriteLine("Choose a demo:");
            Console.WriteLine("1. Temperature Tracker (1D Array)");
            Console.WriteLine("2. Mood Tracker (1D Array + Input)");
            Console.WriteLine("3. Seating Map (2D Array)");
            Console.WriteLine("4. Noise Map (2D Array)");

            Console.Write("Enter choice (1-4): ");
            string input = Console.ReadLine() ?? String.Empty;

            Console.WriteLine();

            if (input == "1")
            {
                // var t = new TemperatureTracker();
                TemperatureTracker t = new();
                t.ShowTemperatures();
            }
            else if (input == "2")
            {
                MoodTracker.Run();
            }
            else if (input == "3")
            {
                var map = new SeatMap();
                map.DisplaySeats();
            }
            else if (input == "4")
            {
                NoiseMap.Run();
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}
