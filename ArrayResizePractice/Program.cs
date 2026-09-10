using System;

class Program
{
    static void Main()
    {
        int[] dataArray = { 97, 7, 18, 1, 1002, 678, 5, 57, 99, 743, 9, 237, 913, 2, 67, 10, 58, 478, 4, 387, 0, 97, 683, 743, 8, 3, 6 };

        Console.Write("The Array data is: ");
        foreach (int data in dataArray)
        {
            Console.Write($"{data} ");
        }
        Console.WriteLine();

        // Keep a reference to the original array
        int[] originalRef = dataArray;

        // Resize the array (increase size by 5)
        Array.Resize(ref dataArray, dataArray.Length + 5);

        // Check if both references point to the same array
        bool sameReference = ReferenceEquals(originalRef, dataArray);

        Console.WriteLine($"\nAfter resizing, array length: {dataArray.Length}");
        Console.WriteLine($"Do both variables reference the same array? {sameReference}");

        // Show the resized array
        Console.Write("Resized Array data is: ");
        foreach (int data in dataArray)
        {
            Console.Write($"{data} ");
        }
        Console.WriteLine();
    }
}
