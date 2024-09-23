int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
int n = parameters[0], s = parameters[1], x = parameters[2];

int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

Queue<int> queue = new Queue<int>();

for (int i = 0; i < n; i++) queue.Enqueue(data[i]);
for (int i = 0; i < s; i++) queue.Dequeue();

if (queue.Count == 0) Console.WriteLine(0);
else if (queue.Contains(x)) Console.WriteLine("true");
else Console.WriteLine(queue.Min());