int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
int rows = dimensions[0];
int cols = dimensions[1];

int[,] matrix = new int[rows, cols];

for (int i = 0; i < rows; i++)
{
    int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

    for (int j = 0; j < cols; j++)
    {
        matrix[i, j] = data[j];
    }
}

for(int col = 0; col < cols; col++) // Iterate all columns
{
    int sum = 0;
    for (int row = 0; row < rows; row++) // Iterate all rows for j-th column
    {
        sum += matrix[row, col];
    }
    
    Console.WriteLine(sum);
}
