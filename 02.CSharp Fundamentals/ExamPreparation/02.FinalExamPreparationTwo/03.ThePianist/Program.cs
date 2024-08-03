namespace _03.ThePianist
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, (string composer, string key)> pieces = new Dictionary<string, (string, string)>();

            for (int i = 0; i < n; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split('|');
                string piece = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];

                pieces[piece] = (composer, key);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Stop")
                {
                    break;
                }

                string[] commandParts = command.Split('|');
                string action = commandParts[0];

                switch (action)
                {
                    case "Add":
                        string pieceToAdd = commandParts[1];
                        string composerToAdd = commandParts[2];
                        string keyToAdd = commandParts[3];

                        if (pieces.ContainsKey(pieceToAdd))
                        {
                            Console.WriteLine($"{pieceToAdd} is already in the collection!");
                        }
                        else
                        {
                            pieces[pieceToAdd] = (composerToAdd, keyToAdd);
                            Console.WriteLine($"{pieceToAdd} by {composerToAdd} in {keyToAdd} added to the collection!");
                        }
                        break;

                    case "Remove":
                        string pieceToRemove = commandParts[1];

                        if (pieces.ContainsKey(pieceToRemove))
                        {
                            pieces.Remove(pieceToRemove);
                            Console.WriteLine($"Successfully removed {pieceToRemove}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {pieceToRemove} does not exist in the collection.");
                        }
                        break;

                    case "ChangeKey":
                        string pieceToChange = commandParts[1];
                        string newKey = commandParts[2];

                        if (pieces.ContainsKey(pieceToChange))
                        {
                            var (composer, _) = pieces[pieceToChange];
                            pieces[pieceToChange] = (composer, newKey);
                            Console.WriteLine($"Changed the key of {pieceToChange} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {pieceToChange} does not exist in the collection.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.composer}, Key: {piece.Value.key}");
            }
        }
    }
}
