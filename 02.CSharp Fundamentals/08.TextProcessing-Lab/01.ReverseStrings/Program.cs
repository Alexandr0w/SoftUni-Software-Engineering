﻿namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != "end")
            {
                string reversed = "";
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    reversed += line[i];
                }

                Console.WriteLine($"{line} = {reversed}");
            }
        }
    }
}
