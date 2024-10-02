int n = int.Parse(Console.ReadLine());

long[][] triangle = new long[n][];

for (int i = 0; i < n; i++)
{
    long[] currentRow = new long[i + 1];
    currentRow[0] = 1;
    currentRow[currentRow.Length - 1] = 1;
    
    triangle[i] = currentRow;
}

for (int i = 2; i < triangle.Length; i++)
{
    for (int j = 1; j < triangle[i].Length - 1; j++)
    {
        triangle[i][j] = triangle[i - 1][j] + triangle[i - 1][j - 1];
    }
}

foreach (long[] row in triangle)
{
    Console.WriteLine(string.Join(" ", row));
}