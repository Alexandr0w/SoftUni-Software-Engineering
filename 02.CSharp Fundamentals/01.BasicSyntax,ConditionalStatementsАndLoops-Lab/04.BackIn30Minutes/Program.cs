using System;

class Program
{
    static void Main()
    {
        //Console.Write("Enter the hours (0-23): ");
        int hours = int.Parse(Console.ReadLine());

        //Console.Write("Enter the minutes (0-59): ");
        int minutes = int.Parse(Console.ReadLine());

        //(int newHours, int newMinutes) = Add30Minutes(hours, minutes);
        int totalMinutes = hours * 60 + minutes;
        totalMinutes += 30;

        int newHours = totalMinutes / 60;
        int newMinutes = totalMinutes % 60;
        if(newHours == 24)
        {
            newHours = 0;
        }

        Console.WriteLine($"{newHours}:{newMinutes:D2}");
    }
}
