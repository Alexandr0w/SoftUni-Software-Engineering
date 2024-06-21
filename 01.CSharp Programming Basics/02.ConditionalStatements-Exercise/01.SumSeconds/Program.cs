int firstTime = int.Parse(Console.ReadLine());  // въведено първо време
int secondTime = int.Parse(Console.ReadLine()); // въведено второ време
int thirdTime = int.Parse(Console.ReadLine()); // въведено трето време

int totalTime = firstTime + secondTime + thirdTime;  // общото време

int minutes = totalTime / 60;  // делим общото време на 60 да намерим минутите
int seconds = totalTime % 60; // делим общото време модулно на 60 да намерим остатъка

if( seconds < 10) // ако секундите са под 10 да направи
{
    Console.WriteLine($"{minutes}:0{seconds}");
}
else // ако не са да отпечата
{
    Console.WriteLine($"{minutes}:{seconds}");
}
