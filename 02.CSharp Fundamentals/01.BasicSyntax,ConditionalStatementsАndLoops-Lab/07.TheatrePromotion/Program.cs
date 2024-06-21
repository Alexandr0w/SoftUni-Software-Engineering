string day = Console.ReadLine();
int age = int.Parse(Console.ReadLine());
int price = 0;


if (day == "Weekday")
{
    if (age >= 0 && age <= 18)
    {
        price = 12;
    }
    else if (age >= 19 && age <= 64)
    {
        price = 18;
    }
    else if (age >= 65 && age <= 122)
    {
        price = 12;
    }
}
else if (day =="Weekend")
{
    if (age >= 0 && age <= 18)
    {
        price = 15;
    }
    else if (age >= 19 && age <= 64)
    {
        price = 20;
    }
    else if (age >= 65 && age <= 122)
    {
        price = 15;
    }
}
else
{
    if (age >= 0 && age <= 18)
    {
        price = 5;
    }
    else if (age >= 19 && age <= 64)
    {
        price = 12;
    }
    else if (age >= 65 && age <= 122)
    {
        price = 10;
    }
}
if(age < 0 || age > 122)
{
    Console.WriteLine("Error!");
}
else
{
    Console.WriteLine($"{price}$");
}