int countOfPeople = int.Parse(Console.ReadLine());
string season  = Console.ReadLine();
double priceForNight = 0;

switch (season)
{
    case "spring":
        {
            if (countOfPeople > 5)
            {
                priceForNight = 48;
            }
            else
            {
                priceForNight = 50;
            }
            break;
        }
    case "summer":
        {
            if (countOfPeople > 5)
            {
                priceForNight = 45;
            }
            else
            {
                priceForNight = 48.50;
            }
            break;
        }
    case "autumn":
        {
            if (countOfPeople > 5)
            {
                priceForNight = 49.50;
            }
            else
            {
                priceForNight = 60.00;
            }
            break;
        }
    case "winter":
        {
            if (countOfPeople > 5)
            {
                priceForNight = 85.00;
            }
            else
            {
                priceForNight = 86.00;
            }
            break;
        }
}
double totalPrice = priceForNight * countOfPeople;
if (season == "summer")
{
    totalPrice *= 0.85;
}
else if (season == "winter")
{
    totalPrice *= 1.08;
}

Console.WriteLine($"{totalPrice:F2} leva.");