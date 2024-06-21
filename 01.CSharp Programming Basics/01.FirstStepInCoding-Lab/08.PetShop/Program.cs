int countOfFoodForDog = int.Parse(Console.ReadLine());
int countOfFoodForCat = int.Parse(Console.ReadLine());

double pricePerDogFood = 2.5;
double pricePerCatFood = 4;
double finalSum = countOfFoodForDog * pricePerDogFood + countOfFoodForCat * pricePerCatFood;

Console.WriteLine($"{finalSum} lv.");