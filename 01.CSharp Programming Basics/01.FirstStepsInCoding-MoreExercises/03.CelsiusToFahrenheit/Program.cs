double celsius = double.Parse(Console.ReadLine());

//°F = (9/5 × °C) + 32.
double fahr = (celsius * 9 / 5) + 32;  // формула за °F към °C

Console.WriteLine($"{fahr:F2}");