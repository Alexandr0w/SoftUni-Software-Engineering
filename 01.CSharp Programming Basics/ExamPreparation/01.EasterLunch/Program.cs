int easterBread = int.Parse(Console.ReadLine());
int pieceEggs = int.Parse(Console.ReadLine());
int kgCookies  = int.Parse(Console.ReadLine());

double priceForBread = easterBread * 3.20;
double priceForEggs = pieceEggs * 4.35;
double priceForCookies = kgCookies * 5.40;
double priceForPaint = pieceEggs * 12 * 0.15;
double TotalPrice = priceForBread + priceForEggs + priceForCookies + priceForPaint;

Console.WriteLine($"{TotalPrice:F2}");