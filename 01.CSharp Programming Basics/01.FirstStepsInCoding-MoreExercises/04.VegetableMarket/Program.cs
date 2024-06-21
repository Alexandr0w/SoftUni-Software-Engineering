double priceKgVeg = double.Parse(Console.ReadLine());
double priceKgFruits = double.Parse(Console.ReadLine());
double totalKgVeg = double.Parse(Console.ReadLine()) * priceKgVeg;
double totalKgFruits = double.Parse(Console.ReadLine()) * priceKgFruits;
double curEuro = 1.94;

double sum = (totalKgVeg + totalKgFruits) / curEuro; // сумата на зеленчуците + плодовете делено на еврото

Console.WriteLine($"{sum:F2}");