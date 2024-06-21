double side = double.Parse(Console.ReadLine());
double height = double.Parse(Console.ReadLine());

double area = side * height / 2; // формула за лице на триъгълник

Console.WriteLine($"{area:F2}");
