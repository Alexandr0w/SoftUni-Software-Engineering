double budgetForMovie = double.Parse(Console.ReadLine()); // бюджета за филма
int numberOfExtras = int.Parse(Console.ReadLine()); // броят статисти
double priceForClothesOfOneExtra = double.Parse(Console.ReadLine()); // цената за дрехите

double priceForDecor = budgetForMovie * 0.10; // сумата за декора
double totalPriceForClothes = numberOfExtras * priceForClothesOfOneExtra; // общата сума за дрехите

if (numberOfExtras > 150)  // ако статистите са повече от 150
{
    totalPriceForClothes = totalPriceForClothes - totalPriceForClothes * 0.10;  // от общата цена правим 10процента отстъпка
}

double totalPriceForAll = totalPriceForClothes + priceForDecor;  // намираме общата сума за дрехите и декора

if (totalPriceForAll <= budgetForMovie) // ако общата сума е по-малка от бюджета
{
    double moneyLeft = budgetForMovie - (priceForDecor + totalPriceForClothes);  // смятаме колко пари са останали
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {moneyLeft:F2} leva left.");
}
else // ако не са
{
    double moneyNeeded = (priceForDecor + totalPriceForClothes) - budgetForMovie; // смятаме колко пари са нужни
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {moneyNeeded:F2} leva more.");
}