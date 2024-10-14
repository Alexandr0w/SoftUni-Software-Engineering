int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

char[][] matrix = new char[rows][];
for (int i = 0; i < rows; i++)
{
    matrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
}

int count = 0;

for (int i = 0; i < rows - 1; i++)
{
    for (int j = 0; j < cols - 1; j++)
    {
        bool isEqual = matrix[i][j] == matrix[i][j + 1] && matrix[i][j] == matrix[i + 1][j] && matrix[i][j] == matrix[i + 1][j + 1];
    
        if (isEqual)
        {
            count++;
        }
    }
}

Console.WriteLine(count);