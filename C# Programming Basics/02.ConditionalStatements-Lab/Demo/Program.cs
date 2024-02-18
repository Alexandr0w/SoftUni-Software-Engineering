// DEMO 1
int a = int.Parse(Console.ReadLine());

if (a >= 6)
{
    Console.WriteLine("Number is > or = than 6");
}
else
{
    Console.WriteLine("Number is lower than 6");
}
// END DEMO 1

// DEMO 2
double num1 = double.Parse(Console.ReadLine());

Console.WriteLine("Ceiling: " + Math.Ceiling(num1));  // нагоре закръглява
Console.WriteLine("Floor: " + Math.Floor(num1));  // надолу закръглява */

// DEMO 3
int num2 = int.Parse(Console.ReadLine());

Console.WriteLine("Abs: " + Math.Abs(num2)); // абсолютна стойност от 0 до num

double num3 = 9.75231;

Console.WriteLine("num = "+ Math.Round(num3, 2));

Console.WriteLine();

Console.WriteLine($"num = {num3}"); 
Console.WriteLine($"num = {num3:F2}");
// END DEMO 3

// DEMO 4
int num4 = int.Parse(Console.ReadLine());

if(num4 == 0)
{
    Console.WriteLine("0");
}
else if(num4 == 1)
{
    Console.WriteLine("1");
}
else if(num4 > 0)
{
    Console.WriteLine("Num > 0");
}
// END DEMO 4