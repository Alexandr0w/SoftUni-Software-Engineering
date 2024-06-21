int wonGames = 0;
int lostGames = 0;
int drawnGames = 0;

for (int i = 0; i < 3; i++)
{
    string result = Console.ReadLine();
    string[] scores = result.Split(':');
    int homeGoals = int.Parse(scores[0]);
    int awayGoals = int.Parse(scores[1]);

    if (homeGoals > awayGoals)
    {
        wonGames++;
    }
    else if (homeGoals < awayGoals)
    {
        lostGames++;
    }
    else
    {
        drawnGames++;
    }
}

Console.WriteLine($"Team won {wonGames} games.");
Console.WriteLine($"Team lost {lostGames} games.");
Console.WriteLine($"Drawn games: {drawnGames}");