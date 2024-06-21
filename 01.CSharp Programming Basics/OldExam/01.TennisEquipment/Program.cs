// Прочитане на входните данни
double racketPrice = double.Parse(Console.ReadLine());
int racketCount = int.Parse(Console.ReadLine());
int shoesCount = int.Parse(Console.ReadLine());

// Изчисляване на цената на маратонките
double shoesPrice = racketPrice / 6;

// Обща цена на ракетите
double totalRacketPrice = racketPrice * racketCount;

// Обща цена на маратонките
double totalShoesPrice = shoesPrice * shoesCount;

// Цена на останалата екипировка (20% от общата цена на ракетите и маратонките)
double additionalEquipmentPrice = 0.2 * (totalRacketPrice + totalShoesPrice);

// Обща цена
double totalPrice = totalRacketPrice + totalShoesPrice + additionalEquipmentPrice;

// Цена, която трябва да плати Джокович (1/8 от общата цена)
double djokovicPrice = totalPrice / 8;

// Цена, която трябва да платят спонсорите (7/8 от общата цена)
double sponsorsPrice = totalPrice - djokovicPrice;

// Отпечатване на резултата, закръглен до по-малкото и по-голямото цяло число
Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(djokovicPrice)}");
Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsorsPrice)}");