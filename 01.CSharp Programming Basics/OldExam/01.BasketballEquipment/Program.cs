int yearTax = int.Parse(Console.ReadLine());

double basketShoes = yearTax - yearTax * 0.4;
double basketClothes = basketShoes - basketShoes * 0.2;
double basketBall = basketClothes / 4;
double basketAccessories = basketBall / 5;

double Sum = yearTax + basketShoes + basketClothes + basketBall + basketAccessories;

Console.WriteLine($"{Sum:F2}");