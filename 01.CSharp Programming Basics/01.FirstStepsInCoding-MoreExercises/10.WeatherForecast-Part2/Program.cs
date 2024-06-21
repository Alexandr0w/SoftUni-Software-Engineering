double celsius = double.Parse(Console.ReadLine());

if (celsius < 5)
{
    Console.WriteLine("undefined");
}
else if (celsius <= 11.9)
{
    Console.WriteLine("Cold");
}
else if (celsius <= 14.9)
{
    Console.WriteLine("Cool");
}
else if (celsius <= 20.00)
{
    Console.WriteLine("Mild");
}
else if (celsius <= 25.9)
{
    Console.WriteLine("Warm");
}
else if (celsius <= 35.00)
{
    Console.WriteLine("Hot");
}
else if (celsius > 35.00)
{
    Console.WriteLine("undefined");
}