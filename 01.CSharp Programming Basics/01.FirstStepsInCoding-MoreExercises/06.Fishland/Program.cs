double priceSkumriq = double.Parse(Console.ReadLine());
double priceCaca  = double.Parse(Console.ReadLine());
double kgPalamud  = double.Parse(Console.ReadLine());
double kgSafrid = double.Parse(Console.ReadLine());
double kgMidi = double.Parse(Console.ReadLine());

double priceMidi = 7.50;

double pricePalamud = priceSkumriq + (priceSkumriq * 0.60); // цена за паламуд
double priceSafrid = priceCaca + (priceCaca * 0.80); // цена за сафрид

double sumPalamud = kgPalamud * pricePalamud; // сума паламуд = кг по бройката
double sumSafrid = kgSafrid * priceSafrid; // сума сафрид = кг по бройката
double sumMidi = kgMidi * priceMidi; // сума миди = кг по бройката

double total = sumPalamud + sumSafrid + sumMidi; // общата сума

Console.WriteLine($"{total:F2}");