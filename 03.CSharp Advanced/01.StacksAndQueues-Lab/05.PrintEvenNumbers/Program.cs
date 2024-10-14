int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

Queue<int> queue = new Queue<int>();

foreach (var integer in integers)
{
    queue.Enqueue(integer);
}

List<int> output = new List<int>();

while (queue.Count > 0)
{
    int currentInteger = queue.Peek();

    if (queue.Dequeue() % 2 == 0)
    {
        output.Add(currentInteger);
    }

}

Console.WriteLine(string.Join(", ", output));