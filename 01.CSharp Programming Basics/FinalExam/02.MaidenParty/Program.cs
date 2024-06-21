double priceForParty = double.Parse(Console.ReadLine());
int message = int.Parse(Console.ReadLine());
int roses = int.Parse(Console.ReadLine());
int keyChains = int.Parse(Console.ReadLine());
int cartoons = int.Parse(Console.ReadLine());
int luckSurprise  = int.Parse(Console.ReadLine());

double priceForMessage = message * 0.60;
double priceForRoses = roses * 7.20;
double priceForKeyChains = keyChains * 3.60;
double PriceForCartoons = cartoons * 18.20;
double priceForLuckSurprise = luckSurprise * 22;

double totalPrice = priceForMessage + priceForRoses + priceForKeyChains + PriceForCartoons + priceForLuckSurprise;
double countOfItems = message + roses + keyChains + cartoons;

if (countOfItems >= 25)
{
    totalPrice *= 0.65;
}

totalPrice *= 0.90;

if (totalPrice >= priceForParty)
{
    double remainingMoney = priceForParty - totalPrice;
    Console.WriteLine($"Yes! {Math.Abs(remainingMoney):F2} lv left.");
}
else
{
    double neededMoney = totalPrice - priceForParty;
    Console.WriteLine($"Not enough money! {Math.Abs(neededMoney):F2} lv needed.");
}
