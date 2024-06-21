int taxPerYear = int.Parse(Console.ReadLine());

// кецовете - 40% по-малко от талсата за една година
double shoes = taxPerYear - taxPerYear * 0.4;

// екин - 20% по-евтин от кецовете
double outfit = shoes - shoes * 0.2;

// топката - 1/4 от цената на екипа
double ball = outfit / 4;

// аксесоарите - 1/5 от цената на топката
double acc = ball / 5;

double sum = taxPerYear + shoes + outfit + ball + acc;
Console.WriteLine(sum);