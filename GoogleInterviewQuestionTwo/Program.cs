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
                if (fills.Length == 0 || fills.Length < 3)
                    return 0;

                int ans = 0;
                int size = fills.Length;

                int[] left_max = new int[size];
                int[] right_max = new int[size];

                left_max[0] = fills[0];

                for (int i = 1; i < size; i++)
                {
                    left_max[i] = Math.Max(fills[i], left_max[i - 1]);
                }
                right_max[size - 1] = fills[size - 1];
                for (int i = size - 2; i >= 0; i--)
                {
                    right_max[i] = Math.Max(fills[i], right_max[i + 1]);
                }
                for (int i = 1; i < size - 1; i++)
                {
                    ans += Math.Min(left_max[i], right_max[i]) - fills[i];
                }
                return ans;
            }

            //Brutal force gone wrong kkk
            //int CheckVolumeFill(int[] fills)
            //{
            //    int response = 0;
            //    var volume = Descompress(fills, 1, response);
            //    return volume;
            //}

            //int Descompress(int[] fills, int interator, int response)
            //{
            //    while (fills[interator] <= fills[interator - 1])
            //    {
            //        interator++;
            //    }
            //    var max = fills[interator];
            //    interator++;
            //    while (interator < (fills.Length - 1))
            //    {
            //        if (max > fills[interator])
            //            response = response + (max - fills[interator]);
            //        else
            //        {
            //            if (max <= fills[interator])
            //            {
            //                break;
            //            }
            //        }
            //        interator++;
            //    }

            //    if (interator < (fills.Length - 1))
            //        response = Descompress(fills, interator, response);

            //    return response;
            //}
        }
    }
}
