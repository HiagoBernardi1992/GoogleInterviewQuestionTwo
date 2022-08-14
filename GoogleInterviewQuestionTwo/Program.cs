using System;
using System.Collections.Generic;

namespace GoogleInterviewQuestionTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Imagine an island that is in the shape of a bar graph. When it rains, certain areas of the island fill up with rainwater to form lakes. Any excess rainwater the island cannot hold in lakes will run off the island to the west or east and drain into the ocean.
            //Given an array of positive integers representing 2 - D bar heights, design an algorithm(or write a function) that can compute the total volume(capacity) of water that could be held in all lakes on such an island given an array of the heights of the bars.Assume an elevation map where the width of each bar is 1.
            //Example: Given[1, 3, 2, 4, 1, 3, 1, 4, 5, 2, 2, 1, 4, 2, 2], return 15(3 bodies of water with volumes of 1, 7, 7 yields total volume of 15)
            int[] f = { 1, 3, 2, 4, 1, 3, 1, 4, 5, 2, 2, 1, 4, 2, 2 };
            var result = CheckVolumeFill(f);
            Console.WriteLine("Esperado: 15");
            Console.WriteLine("Resultado: " + result.ToString());

            int CheckVolumeFill(int[] fills)
            {
                //fist I check if the size can generate something to fill if not I just return already
                if (fills.Length == 0 || fills.Length < 3)
                    return 0;

                //varaible to storage the quantity
                int ans = 0;
                //variable to check the size of the graph (interation propors)
                int size = fills.Length;
                //variable to storage the max left size of every bar 

                int[] left_max = new int[size];
                //variable to storage the max rigth size of every bar 
                int[] right_max = new int[size];

                //In the left check I know that the first item always be himself because his don't have a left bar to compare
                left_max[0] = fills[0];
                //So I do a loop to check left to rigth
                for (int i = 1; i < size; i++)
                {
                    //if the left item is bigger than the current graph I put this at same position, if not I put the bar value instead
                    left_max[i] = Math.Max(fills[i], left_max[i - 1]);
                }

                //In the rigth check I know that the last item always be himself because his don't have a rigth bar to compare
                right_max[size - 1] = fills[size - 1];
                for (int i = size - 2; i >= 0; i--)
                {
                    //if the rigth item is bigger than the current graph I put this at same position, if not I put the bar value instead
                    right_max[i] = Math.Max(fills[i], right_max[i + 1]);
                }
                //Now that I know the 2 sides bigger value and both have the same size
                for (int i = 1; i < size - 1; i++)
                {
                    //I check what is the lower of the to size and just subtract the current bar of the lower
                    ans += Math.Min(left_max[i], right_max[i]) - fills[i];
                }
                return ans;
            }
        }
    }
}
