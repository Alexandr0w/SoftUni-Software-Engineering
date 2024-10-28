namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string command = Console.ReadLine();
            while (command != "END")
            {
                try
                {
                    ProcessCommand(command, teams);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }
        }
        private static void ProcessCommand(string command, Dictionary<string, Team> teams)
        {
            string[] data = command.Split(";");

            if (data[0] == "Team")
            {
                Team team = new Team(data[1]);
                teams[team.Name] = team;
            }
            else
            {
                string teamName = data[1];
                if (!teams.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist.");
                    return;
                }

                Team team = teams[teamName];
                if (data[0] == "Add")
                {
                    Player player = new Player(data[2], int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]));

                    team.AddPlayer(player);
                }
                else if (data[0] == "Remove")
                {
                    string playerName = data[2];
                    if (!team.RemovePlayer(playerName))
                    {
                        Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                    }
                }
                else if (data[0] == "Rating")
                {
                    Console.WriteLine($"{team.Name} - {team.Rating}");
                }
            }
        }
    }
}