double menuChicken = 10.35;
double menuFish = 12.40;
double menuVegan = 8.15;
double transport = 2.50;

int countmenuChicken = int.Parse(Console.ReadLine());
int countmenuFish = int.Parse(Console.ReadLine());
int countmenuVegan = int.Parse(Console.ReadLine());

double priceMenuChicken = menuChicken * countmenuChicken;  // цена за пилешко меню
double pricemenuFish = menuFish * countmenuFish; // цена за рибно меню
double pricemenuVegan = menuVegan * countmenuVegan; // цена за веган меню

double price = priceMenuChicken + pricemenuFish + pricemenuVegan; // обща цена
double desertPrc = price * 0.20; // цена за десерта
double finalPrice = price + desertPrc + transport; // обща цена

Console.WriteLine($"Price for the order is {finalPrice} BGN.");