Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

int capacity = int.Parse(Console.ReadLine());
int racks = 1;
int currentCapacity = capacity;

while (clothes.Count > 0)
{
    int currentClothes = clothes.Pop();

    if (currentClothes <= currentCapacity)
    {
        currentCapacity -= currentClothes;
    }
    else
    {
        racks++;
        currentCapacity = capacity - currentClothes;
    }
}

Console.WriteLine(racks);
