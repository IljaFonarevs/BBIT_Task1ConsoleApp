using System.Linq;
using System.Collections.Generic;
using System.Globalization;

class uzd1
{
    private const int MIN = 1;
    private const int MAX = 9999;

    private static Random rnd = new Random();
    private static List<int> Values = new List<int>();

    public static void Main(string[] args)
    {

        int[,] matrix = new int[20, 20];
        

        //Creating and outputing 20x20 array

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++) matrix[i, j] = GenerateUniqueRandomValue(MIN, MAX);
        }
        Console.WriteLine("Original array: \n");
        Print2DArray(matrix);

        //MinMax numbers and its coordinates.

        Console.WriteLine("MinMax points and their coordinates: \n");
        int[,] results = FindMinAndMax(matrix);
        Console.WriteLine($"Maximum value is: {results[0, 1]} It's coordinates: [{results[2, 0]},{results[2, 1]}] \n");
        Console.WriteLine($"Minimum value is: {results[0, 0]} It's coordinates: [{results[1, 0]},{results[1, 1]}] \n");

        //Sorting array
        Console.WriteLine("Sorted Array: \n");
        matrix = Sort2DArray(matrix);
        Print2DArray(matrix);

    }


    private static int GenerateUniqueRandomValue(int min, int max)
    {

        int generatedValue;
        

        while (true)
        {
            generatedValue = rnd.Next(min, max);

            // Check if the generetated value already exists, if not - trying again
            if (Values.Contains(generatedValue)) continue;
            
            //If there is no such value, stop the cycle and return the generated value
            Values.Add(generatedValue);
            break;
            
        }
        return generatedValue;
    }

    private static void Print2DArray(int[,] array)
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++) { Console.Write(array[i, j] + " "); }
            Console.WriteLine("\n");
        }
    }

    private static int[,] FindMinAndMax(int[,] matrix)
    {
        int min = MAX+1;
        int max = MIN-1;


        int MinXCord = 0;
        int MinYCord = 0;

        int MaxXCord = 0;
        int MaxYCord = 0;



        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    MinYCord = i;
                    MinXCord = j;
                }
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    MaxYCord = i;
                    MaxXCord = j;
                }
            }
        }
        // Returns two-dimensional array, in the first sub-array, contains only the lowest number, in the seconds sub-array containts the min coordinates, in the third sub-array containts the max coordinates

        return new int[,] { 
            { min, max }, { MinYCord + 1, MinXCord + 1 },{MaxYCord + 1, MaxXCord + 1} 
        };


    }
    private static int[,] Sort2DArray(int[,] matrix)
    {
        int y = 0;

        // Creates a list with the same values as a 2D array, converts the list to the one dimensional array, sorts that one dimensional array, and then converts it back to the two-dimensional array

        var list = matrix.OfType<int>().ToList();
        int[] Unsorted = list.ToArray();
        Array.Sort(Unsorted);

        int[,] Sorted = new int[20, 20];
        
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Sorted[i, j] = Unsorted[y++];
            }
        }
        
        return Sorted;
    }
}
