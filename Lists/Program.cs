using System;
using MyListLibrary;

namespace ListApp
{
    class Program
    {
        static void PrintList(MyCharList list)
        {
            foreach (var c in list)
                Console.Write(c + " ");
            Console.WriteLine();
        }

        static void Main()
        {
            MyCharList list = new MyCharList();
            foreach (char c in new char[] { 's', '$', 'J', '@', 'X', '#', '№', 'Z', 'b' })
                list.Add(c);

            Console.WriteLine("Initial list:");
            PrintList(list);

            Console.WriteLine("\nTASK 1: Find first occurrence of '№'");
            int index = list.IndexOf('№');
            if (index != -1)
                Console.WriteLine($"First occurrence of '№' is at index: {index}");
            else
                Console.WriteLine("Element not found.");

            Console.WriteLine("\nTASK 2: Sum of ASCII values at odd positions");
            Console.WriteLine($"Sum = {list.SumOddPositions()}");

            Console.WriteLine("\nTASK 3: Elements greater than 'X'");
            var greaterList = list.GetElementsGreaterThan('X');
            PrintList(greaterList);

            Console.WriteLine("\nTASK 4: Remove elements > average");
            list.RemoveGreaterThanAverage();
            PrintList(list);

            Console.WriteLine("\nTesting indexer and RemoveAt:");
            Console.WriteLine($"Element at index 2: {list[2]}");
            list.RemoveAt(2);
            Console.WriteLine("After removing element at index 2:");
            PrintList(list);
        }
    }
}
