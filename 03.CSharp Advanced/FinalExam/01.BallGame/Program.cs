Stack<int> strengths = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> accuracies = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

int totalGoals = 0;

while (strengths.Count > 0 && accuracies.Count > 0)
{
    int lastStrength = strengths.Peek();
    int firstAccuracy = accuracies.Peek();

    int sum = lastStrength + firstAccuracy;


    if (sum == 100)
    {
        strengths.Pop();
        accuracies.Dequeue();
        totalGoals++;
    }
    else if (sum < 100)
    {
        if (lastStrength < firstAccuracy)
        {
            strengths.Pop();
        }
        else if (lastStrength > firstAccuracy)
        {
            accuracies.Dequeue();
        }
        else
        {
            int newStrength = lastStrength + firstAccuracy;
            strengths.Pop();
            strengths.Push(newStrength);
            accuracies.Dequeue();
        }
    }
    else
    {
        strengths.Pop();
        strengths.Push(lastStrength - 10);
        accuracies.Enqueue(accuracies.Dequeue());
    }
}

if (totalGoals == 0)
{
    Console.WriteLine("Paul failed to score a single goal.");
}
else if (totalGoals == 3)
{
    Console.WriteLine("Paul scored a hat-trick!");
}
else if (totalGoals > 3)
{
    Console.WriteLine("Paul performed remarkably well!");
}
else
{
    Console.WriteLine("Paul failed to make a hat-trick.");
}
if (totalGoals > 0)
{
    Console.WriteLine($"Goals scored: {totalGoals}");
}
if (strengths.Count > 0)
{
    Console.WriteLine($"Strength values left: { string.Join(", ", strengths) }");
}
if (accuracies.Count > 0)
{
    Console.WriteLine($"Accuracy values left: { string.Join(", ", accuracies) }");
}