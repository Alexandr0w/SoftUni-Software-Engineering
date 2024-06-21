int number = int.Parse(Console.ReadLine()); // начален брой точки

double bonusPoints = 0;  // бонус точките с някаква стойност в случая 0

if (number <= 100) // проверяваме дали е по-малко или равно на 100
{
    bonusPoints = 5;  // бонус точките да са 5
}
else if (number > 1000)  // проверяваме първо дали е по-голямо от 1000, за да дадем 10процента
{
    bonusPoints = number * 0.1; // правим отстъпката с 10 процента
}
else if (number > 100) // проверяваме дали е по-голямо от 100
{
    bonusPoints = number * 0.2; // правим отстъпката с 20 процента
}

if (number % 2 == 0) // ако броят точки модулно се делят на 2 да остане 0 (т.е. да няма остатък)
{
    bonusPoints = bonusPoints + 1;  // бонус точките ги увеличаваме с +1
    // bonusPoints += 1; --> кратък запис 
}
else if (number % 5 == 0)  // ако броят точки модулно се делят на 5 да няма остатък
{
    bonusPoints = bonusPoints + 2; // бонус точките ги увеличаваме с +2
    // bonusPoints += 2; --> кратък запис 
}

Console.WriteLine(bonusPoints);
Console.WriteLine(number + bonusPoints);