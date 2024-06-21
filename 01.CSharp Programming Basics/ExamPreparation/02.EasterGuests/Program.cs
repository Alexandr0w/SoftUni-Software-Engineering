// Prices
double easterBreadPrice = 4.0;
double eggPrice = 0.45;

// Input
int guests = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());

// Calculations
int easterBreadsNeeded = (guests + 2) / 3; // Ensure rounding up to cover all guests
int eggsNeeded = guests * 2;

double totalEasterBreadPrice = easterBreadPrice * easterBreadsNeeded;
double totalEggPrice = eggPrice * eggsNeeded;
double totalPrice = totalEasterBreadPrice + totalEggPrice;

// Output
if (totalPrice <= budget)
{
    double moneyLeft = budget - totalPrice;
    Console.WriteLine($"Lyubo bought {easterBreadsNeeded} Easter bread and {eggsNeeded} eggs.");
    Console.WriteLine($"He has {moneyLeft:f2} lv. left.");
}
else
{
    double moneyNeeded = totalPrice - budget;
    Console.WriteLine("Lyubo doesn't have enough money.");
    Console.WriteLine($"He needs {moneyNeeded:f2} lv. more.");
}