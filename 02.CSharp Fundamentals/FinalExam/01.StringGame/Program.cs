/*
 //Th1s 1s my str1ng!//
Change 1 i
Includes string
End my
Uppercase
FindIndex I   
*/

namespace _01.StringGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] commandSplit = command.Split(" ");

                if (commandSplit[0] == "Change")
                {
                    char charToReplace = char.Parse(commandSplit[1]);
                    char replacementChar = char.Parse(commandSplit[2]);

                    input = input.Replace(charToReplace, replacementChar);
                    Console.WriteLine(input);
                }

                else if (commandSplit[0] == "Includes")
                {
                    string substring = commandSplit[1];
                    Console.WriteLine(input.Contains(substring) ? "True" : "False");
                }

                else if (commandSplit[0] == "End")
                {
                    string substring = commandSplit[1];
                    Console.WriteLine(input.EndsWith(substring) ? "True" : "False");
                }

                else if (commandSplit[0] == "Uppercase")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }

                else if (commandSplit[0] == "FindIndex")
                {
                    char charToFind = char.Parse(commandSplit[1]);
                    int index = input.IndexOf(charToFind);
                    Console.WriteLine(index);
                }

                else if (commandSplit[0] == "Cut")
                {
                    int startIndex = int.Parse(commandSplit[1]);
                    int count = int.Parse(commandSplit[2]);

                    if (startIndex >= 0 && startIndex < input.Length && count >= 0 &&
                        startIndex + count <= input.Length)
                    {
                        string cutSubstring = input.Substring(startIndex, count);
                        input = cutSubstring;
                        Console.WriteLine(input);
                    }
                }
            }
        }
    }
}
