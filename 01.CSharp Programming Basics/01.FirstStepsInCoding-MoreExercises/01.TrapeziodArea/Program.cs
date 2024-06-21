double b1 = double.Parse(Console.ReadLine());
double b2  = double.Parse(Console.ReadLine());  
double h = double.Parse(Console.ReadLine());

double sum = (b1 + b2) * h / 2;  // формула за лице на трапец

Console.WriteLine($"{sum:F2}");