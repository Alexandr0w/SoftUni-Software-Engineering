// Въвеждане на данните от конзолата
int controlMinutes = int.Parse(Console.ReadLine());
int controlSeconds = int.Parse(Console.ReadLine());
double slopeLength = double.Parse(Console.ReadLine());
int secondsPer100Meters = int.Parse(Console.ReadLine());

// Пресмятане на времето за изминаване на улея в секунди
double slopeTime = (slopeLength / 100) * secondsPer100Meters - Math.Floor(slopeLength / 120) * 2.5;

// Общо време в секунди
double totalTimeInSeconds = slopeTime + (slopeLength / 100 * secondsPer100Meters);

// Превръщане на контролното време в секунди
int controlTotalSeconds = controlMinutes * 60 + controlSeconds;

// Проверка за печелене на квота и извеждане на резултата
if (totalTimeInSeconds < controlTotalSeconds)
{
    Console.WriteLine($"Marin Bangiev won an Olympic quota!");
    Console.WriteLine($"His time is {totalTimeInSeconds:F3}.");
}
else
{
    double secondsDifference = Math.Ceiling(totalTimeInSeconds - controlTotalSeconds);
    Console.WriteLine($"No, Marin failed! He was {secondsDifference:F3} seconds slower.");
}