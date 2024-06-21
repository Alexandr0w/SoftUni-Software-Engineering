int nylon = int.Parse(Console.ReadLine());
int paint = int.Parse(Console.ReadLine());
int thinner = int.Parse(Console.ReadLine());   
int hours  = int.Parse(Console.ReadLine());

double nylonPrice = 1.50;
double paintPrice = 14.50;
double ThinnerPrice = 5.00;

double sumNylon = (nylon + 2) * nylonPrice;  // сума на найлона
double sumPaint = (paint + paint * 0.10) * paintPrice; // сума на боята
double sumТhinnerPrice = thinner * ThinnerPrice; // сума на разредителя

double sumMaterials = sumNylon + sumPaint + sumТhinnerPrice + 0.40; // сума на материалите
double sumWorkers = sumMaterials * 0.30 * hours;  // суима за работниците
double sumTotal = sumMaterials + sumWorkers; // обща сума работници + материали


Console.WriteLine($"Suma nailon: {sumNylon}");
Console.WriteLine($"Suma boya: {sumPaint}");
Console.WriteLine($"Suma razreditel: {sumТhinnerPrice}");
Console.WriteLine($"Suma materiali: {sumMaterials}");
Console.WriteLine($"Suma za rabota: {sumWorkers}");
Console.WriteLine($"Suma obshto: {sumTotal}");