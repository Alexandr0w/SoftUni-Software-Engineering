int peopleCount = int.Parse(Console.ReadLine());


int nights = int.Parse(Console.ReadLine());
int transportCards = int.Parse(Console.ReadLine());
int museumTickets = int.Parse(Console.ReadLine());

double nightPrice = 20.0;
double transportCardPrice = 1.60;
double museumTicketPrice = 6.0;

double totalCost = (peopleCount * nights * nightPrice) + (peopleCount * transportCards * transportCardPrice) + (peopleCount * museumTickets * museumTicketPrice);

totalCost *= 1.25;

Console.WriteLine($"{totalCost:F2}");