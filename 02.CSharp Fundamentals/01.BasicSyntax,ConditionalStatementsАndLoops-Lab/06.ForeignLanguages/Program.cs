using System;

class Program
{
    static void Main()
    {
        //Console.Write("Enter the country name: ");
        string country = Console.ReadLine();

        string spokenLanguage = GetSpokenLanguage(country);
        Console.WriteLine(spokenLanguage);
    }

    static string GetSpokenLanguage(string country)
    {
        switch (country)
        {
            case "England":
            case "USA":
                return "English";
            case "Spain":
            case "Argentina":
            case "Mexico":
                return "Spanish";
            default:
                return "unknown";
        }
    }
}
