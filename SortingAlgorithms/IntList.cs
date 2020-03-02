using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class IntList
    {
        public IntList()
        {
        }

        public IntList(int amount)
        {
            NumList = CreateRandomNumberList(amount);
        }

        private List<int> NumList { get; }


        public static List<int> CreateRandomNumberList(int numAmount)
        {
            var numberlist = new List<int>();

            //Console.WriteLine("Enter amount of numbers");

            // Fill List
            for (var i = 0; i < numAmount; i++) numberlist.Add(i);

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

        public void PrintList()
        {
            foreach (var num in NumList)
            {
                Console.Write(num);
                Console.Write("|");
            }
        }

        public bool IsSorted()
        {
            for (var i = 0; i < NumList.Count - 1; i++)
                if (NumList[i] >= NumList[i + 1])
                    return false;
            return true;
        }


        public List<int> BubbleSort()
        {
            var x = NumList.Count;
            for (var i = 0; i < x - 1; i++)
            for (var j = 0; j < x - i - 1; j++)
                if (NumList[j] > NumList[j + 1])
                {
                    var temp = NumList[j];
                    NumList[j] = NumList[j + 1];
                    NumList[j + 1] = temp;
                }

            return NumList;
        }

        public List<int> BubbleSortOptimized()
        {
            var x = NumList.Count;
            bool swap;
            for (var i = 0; i < x - 1; i++)
            {
                swap = false;
                for (var j = 0; j < x - i - 1; j++)
                    if (NumList[j] > NumList[j + 1])
                    {
                        var temp = NumList[j];
                        NumList[j] = NumList[j + 1];
                        NumList[j + 1] = temp;
                        swap = true;
                    }

                if (swap == false) break;
            }

            return NumList;
        }
    }
}