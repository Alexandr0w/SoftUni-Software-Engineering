int[] array = Console.ReadLine().Split(", ").Select(int.Parse).Where(n => n % 2 == 0).OrderBy(n => n).ToArray();

Console.WriteLine(string.Join(", ", array));