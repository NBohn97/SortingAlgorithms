using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SortingAlgorithms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
            
            // Assign Name and Create Txt File 
            var path = AssignPath();
            var stream = CreateFile(path);
            
            // Fill Txt File With Sorted Numbers
            //CreateNumbers(stream);
            
            // Fill Txt File with Random Numbers
            CreateRandomNumberFile(stream);
            
            // Create a random int List
            //var randList = CreateRandomNumberList(stream);
            
            // Create a sorted List
            var sortList = new List<int>() {1,2,3,4,5,6,8,10,15,254,8651,50000}; 
            
            //Console.WriteLine(isSorted(randList));
            //sortList.ForEach(Console.WriteLine);
            //Console.WriteLine(IsSorted(sortList));

            var convertedList = TxtToList(path);
            //convertedList.ForEach(Console.Write);
            Console.WriteLine(IsSorted(convertedList));
            
            */

            /*
            IntList newList = new IntList(25);
            newList.PrintList();
            Console.WriteLine(newList.IsSorted());
            */
            Console.WriteLine("Enter amount of num:");
            var numAmount = int.Parse(Console.ReadLine());


            var newBubble = new IntList(numAmount);

            //Console.WriteLine("This is the new unsorted List:");
            //newBubble.PrintList();


            Console.WriteLine("\r\nIs unsorted Bubble Sorted?");
            Console.WriteLine(newBubble.IsSorted());
            Console.WriteLine("-------------------------------------------------");

            var sw1 = new Stopwatch();
            sw1.Start();
            var sortedBubble = newBubble.BubbleSort();
            sw1.Stop();
            Console.WriteLine("\r\nIs Sorted Bubble Sorted?");
            Console.WriteLine(IsSorted(sortedBubble));

            //Console.WriteLine("This is the New Sorted List:");
            //PrintList(sortedBubble);
            Console.WriteLine($"\r\nTime Elapsed: {sw1.Elapsed}");
            Console.WriteLine("-------------------------------------------------");

            var sw2 = new Stopwatch();
            sw2.Start();
            var sortedBubble2 = newBubble.BubbleSortOptimized();
            sw2.Stop();
            Console.WriteLine("\r\nIs Sorted Bubble Sorted?");
            Console.WriteLine(IsSorted(sortedBubble2));

            //Console.WriteLine("This is the New Sorted List:");
            //PrintList(sortedBubble2);

            Console.WriteLine($"\r\nTime Elapsed: {sw2.Elapsed}");
            Console.WriteLine("-------------------------------------------------");
        }


        public static string AssignPath()
        {
            var basepath = "E:\\Documents\\SolutionFiles\\AlgoSort\\";
            Console.WriteLine("Enter a file name:");
            var filename = Console.ReadLine() + ".txt";
            var path = basepath + filename;
            return path;
        }


        public static StreamWriter CreateFile(string path)
        {
            //var stream = File.Create(path);
            var stream = new StreamWriter(path, true) {AutoFlush = true};
            return stream;
        }

        public static void CreateNumbers(StreamWriter stream)
        {
            Console.WriteLine("Enter amount of numbers");
            var amount = int.Parse(Console.ReadLine());

            for (var i = 0; i <= amount; i++) stream.WriteLine(i);
            stream.Close();
        }

        // Creates a File Filled with random int
        public static void CreateRandomNumberFile(StreamWriter stream)
        {
            var numberlist = CreateRandomNumberList(stream);

            foreach (var number in numberlist) stream.WriteLine(number);

            stream.Close();
        }


        // Creates a list filled with randomized int 
        public static List<int> CreateRandomNumberList(StreamWriter stream)
        {
            var numberlist = new List<int>();

            Console.WriteLine("Enter amount of numbers");
            var amount = int.Parse(Console.ReadLine());

            // Fill List
            for (var i = 0; i < amount; i++) numberlist.Add(i);

            // Randomize List using Fisher-Yates Shuffle
            var rand = new Random();
            var n = numberlist.Count;

            for (var i = numberlist.Count - 1; i > 1; i--)
            {
                var random = rand.Next(i + 1);
                var value = numberlist[random];
                numberlist[random] = numberlist[i];
                numberlist[i] = value;
            }

            return numberlist;
        }


        // DEPRECATED
        public static bool IsSorted(List<int> randList)
        {
            for (var i = 0; i < randList.Count - 1; i++)
                if (randList[i] >= randList[i + 1])
                    return false;

            return true;
        }


        public static List<int> TxtToList(string path)
        {
            string line;
            var numList = new List<int>();
            var file = new StreamReader(path);

            while ((line = file.ReadLine()) != null) numList.Add(int.Parse(line));

            return numList;
        }

        public static void PrintList(List<int> list)
        {
            foreach (var num in list)
            {
                Console.Write(num);
                Console.Write("|");
            }
        }
    }
}