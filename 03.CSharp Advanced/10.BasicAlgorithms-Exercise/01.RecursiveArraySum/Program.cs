﻿namespace _01.RecursiveArraySum
{
    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(Sum(input));
        }

        public static int Sum(int[] arr, int index = 0)
        {
            if (index == arr.Length)
            {
                return 0;
            }
            var resultSoFar = Sum(arr, index + 1);


            return arr[index] + resultSoFar;
        }
    }
}