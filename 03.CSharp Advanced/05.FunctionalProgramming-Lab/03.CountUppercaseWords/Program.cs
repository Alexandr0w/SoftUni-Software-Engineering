Func<string, string[]> extractUppercaseWords = text => text
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Where(word => char.IsUpper(word[0]))
            .ToArray();

string input = Console.ReadLine();
string[] result = extractUppercaseWords(input);

Console.WriteLine(string.Join(Environment.NewLine, result));