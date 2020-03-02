using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class IntList
    {
        private List<int> numList { get; set; }
        
        public IntList(){}
        
        public IntList(int amount)
        {
            this.numList = CreateRandomNumberList(amount);
        }
        
        
        public static List<int> CreateRandomNumberList(int numAmount)
        {
            var numberlist = new List<int>();
            
            //Console.WriteLine("Enter amount of numbers");
            
            // Fill List
            for (var i = 0; i < numAmount; i++)
            {
                numberlist.Add(i);
            }
            
            // Randomize List using Fisher-Yates Shuffle
            var rand = new Random();
            var n = numberlist.Count;

            for (var i = numberlist.Count - 1; i > 1 ; i--)
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
            foreach (var num in numList )
            {
                Console.Write(num);
                Console.Write("|");
            }
        }
        
        public bool IsSorted()
        {
            for (var i = 0; i < numList.Count-1; i++)
            {
                if (numList[i] >= numList[i + 1])
                {
                    return false;
                } 
            }
            return true;
        }



        public List<int> BubbleSort()
        {
            var x = numList.Count;
            var iteration = 0;
            for (var i = 0; i < x-1; i++)
            {
                for (var j = 0; j < x-i-1; j++)
                    if (numList[j] > numList[j + 1])
                    {
                        var temp = numList[j];
                        numList[j] = numList[j + 1];
                        numList[j + 1] = temp;
                    }
                
                iteration++;
            }

            Console.WriteLine($"Number of Outer Iterations: {iteration}");
            return numList;
        }

        public List<int> BubbleSortOptimized()
        {
            var x = numList.Count;
            var iteration = 0;
            bool swap = true;
            for (var i = 0; i < x-1; i++)
            {
                for (var j = 0; j < x-i-1; j++)
                    if (numList[j] > numList[j + 1])
                    {
                        var temp = numList[j];
                        numList[j] = numList[j + 1];
                        numList[j + 1] = temp;
                    }
                
                iteration++;
            }

            Console.WriteLine($"Number of Outer Iterations: {iteration}");
            return numList;
            }
        }
        
        
        
        
        
        
    }
}