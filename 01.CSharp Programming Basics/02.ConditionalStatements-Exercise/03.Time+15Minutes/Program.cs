int inputHours = int.Parse(Console.ReadLine()); // въведени часове
int inputMinutes = int.Parse(Console.ReadLine()); // въведени минути

int minutesPlus15 = inputMinutes + 15; // минутите + 15 по условие

int hours = inputHours + minutesPlus15 / 60; // преобразуваме часовете от въведените часове + минутите+15 целочислено делено на 60
int minutes = minutesPlus15 % 60; // минутите ги делим модулно на 60, за да ни остане остатък

if (hours == 24)  // ако часовете са равни на 24 да ги направи 0
{
    hours = 0;
}
if (minutes < 10) // ако минутите са по-малко от 10 да направи -->>
{
    Console.WriteLine($"{hours}:0{minutes}");
}
else // ако не са 
{
    Console.WriteLine($"{hours}:{minutes}");
}