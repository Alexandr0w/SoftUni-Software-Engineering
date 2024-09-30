int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

int rows = dimensions[0], cols = dimensions[1];

int[,] matrix = new int[rows, cols];
ReadMatrix(matrix);

int sum = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        sum += matrix[i, j];
    }
}

Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));
Console.WriteLine(sum);

static void ReadMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = data[j];
        }
    }
}