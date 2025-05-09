﻿using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Db Creation Started...");

            try
            {
                using SalesContext dbContext = new SalesContext();

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                Console.WriteLine("Db Creation was successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Db Creation failed!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
