/*
Alva James William
2
*/

string[] input = Console.ReadLine().Split();
int count = int.Parse(Console.ReadLine());

Queue<string> kids = new Queue<string>(input);

while (kids.Count > 1)
{
    for (int i = 0; i < count - 1; i++)
    {
        //kids.Enqueue(kids.Dequeue());
        string currentKid = kids.Dequeue();
        kids.Enqueue(currentKid);
    }

    Console.WriteLine($"Removed {kids.Dequeue()}");
}

Console.WriteLine($"Last is {kids.Dequeue()}");