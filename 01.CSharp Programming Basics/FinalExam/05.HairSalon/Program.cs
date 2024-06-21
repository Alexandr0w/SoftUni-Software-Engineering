int goalForDay = int.Parse(Console.ReadLine());
string input = Console.ReadLine();
string hairstyle;

int totalPrice = 0;
bool isSuccess = false;

while (input != "closed")
{
    if (input == "haircut")
    {
        hairstyle = Console.ReadLine();
        if (hairstyle == "mens")
        {
            totalPrice += 15;
        }
        else if (hairstyle == "ladies")
        {
            totalPrice += 20;
        }
        else if (hairstyle == "kids")
        {
            totalPrice += 10;
        }
    }
    else if (input == "color")
    {
        hairstyle = Console.ReadLine();
        if (hairstyle == "touch up")
        {
            totalPrice += 20; 
        }
        else if (hairstyle == "full color")
        {
            totalPrice += 30;
        }
    }
    if (totalPrice >= goalForDay)
    {
        isSuccess = true;
        break;
    }
    input = Console.ReadLine();
}
if (isSuccess)
{
    Console.WriteLine("You have reached your target for the day!");
}
else
{
    int neededMoney = goalForDay - totalPrice;
    Console.WriteLine($"Target not reached! You need {neededMoney}lv. more.");
}
Console.WriteLine($"Earned money: {totalPrice}lv.");
