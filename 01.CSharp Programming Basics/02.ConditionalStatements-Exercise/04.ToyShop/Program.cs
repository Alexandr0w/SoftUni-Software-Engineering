double priceForTrip = double.Parse(Console.ReadLine());
int piecePuzzel = int.Parse(Console.ReadLine());
int pieceDolls = int.Parse(Console.ReadLine());
int pieceBears = int.Parse(Console.ReadLine());
int pieceMinions = int.Parse(Console.ReadLine());
int pieceTrucks  = int.Parse(Console.ReadLine());

double sumPuzzel = piecePuzzel * 2.6;  // сумата за пъзелите
double sumDolls = pieceDolls * 3; // сумата за куклите
double sumBears = pieceBears * 4.1; // сумата за мечките
double sumMinions = pieceMinions * 8.20; // сумата за минионите
double sumTrucks = pieceTrucks * 2.0; // сумата за камиончетата

double sumToys = sumPuzzel + sumDolls + sumBears + sumMinions + sumTrucks; // общата сума на играчките
int pieceOfToys = piecePuzzel + pieceDolls + pieceBears + pieceMinions + pieceTrucks; // общата бройка на играчките

if (pieceOfToys >= 50) // ако играчките са повече или равни на 50
{
    sumToys *= 0.75;  // правим отстъпка с 25процента (най-краткият запис)
}

double rent = sumToys * 0.1; // смятаме наема за магазина
double finalSum = sumToys - rent; // смятаме финалната сума

if (finalSum >= priceForTrip) // ако финалната сума е по-голяма или равна на цената за екскурзията
{
    double moneyLeft = finalSum - priceForTrip; // смятаме колко пари остават
    Console.WriteLine($"Yes! {moneyLeft:F2} lv left.");
}
else // ако не са
{
    double neededMoney = priceForTrip - finalSum; // смятаме колко пари са ни нужни
    Console.WriteLine($"Not enough money! {neededMoney:F2} lv needed.");
}