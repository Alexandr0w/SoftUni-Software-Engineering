int studentsTickets = 0;
int standardTickets = 0;
int kidTickets = 0;

string filmName = Console.ReadLine();

while (filmName != "Finish")
{
    int freeTickets = int.Parse(Console.ReadLine());

    string ticketsType = string.Empty;
    int buyTickets = 0;

    while (buyTickets < freeTickets)
    {
        ticketsType = Console.ReadLine();
        if (ticketsType == "End")
            break;

        buyTickets++;

        if (ticketsType == "student")
            studentsTickets++;
        else if (ticketsType == "standard")
            standardTickets++;
        else if (ticketsType == "kid")
            kidTickets++;
    }

    double percentFill = (double)buyTickets / freeTickets * 100;
    Console.WriteLine($"{filmName} - {percentFill:F2}% full.");
    filmName = Console.ReadLine();
}

double totalTickets = studentsTickets + standardTickets + kidTickets;
double percentStudents = studentsTickets / totalTickets * 100;
double percentStandard = standardTickets / totalTickets * 100;
double percentKids = kidTickets / totalTickets * 100;

Console.WriteLine($"Total tickets: {totalTickets}");
Console.WriteLine($"{percentStudents:F2}% student tickets.");
Console.WriteLine($"{percentStandard:F2}% standard tickets.");
Console.WriteLine($"{percentKids:F2}% kids tickets.");
