public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = ReadSquareMatrix(n);
        int[,] bombsCoordinates = ReadBombCoordinates();

        for (int i = 0; i < bombsCoordinates.GetLength(0); i++)
        {
            int bombRow = bombsCoordinates[i, 0];
            int bombCol = bombsCoordinates[i, 1];
            ExplodeBomb(matrix, bombRow, bombCol);
        }

        int aliveCellsCount = 0;
        int aliveCellsSum = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] > 0)
                {
                    aliveCellsCount++;
                    aliveCellsSum += matrix[i, j];
                }
            }
        }

        PrintAnswer(matrix, aliveCellsCount, aliveCellsSum);
    }

    private static int[,] ReadSquareMatrix(int n)
    {
        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = data[j];
            }
        }

        return matrix;
    }

    private static int[,] ReadBombCoordinates()
    {
        string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        int[,] bombCoordinates = new int[data.Length, 2];
        for (int i = 0; i < bombCoordinates.GetLength(0); i++)
        {
            int[] coordinates = data[i].Split(",").Select(int.Parse).ToArray();

            for (int j = 0; j < bombCoordinates.GetLength(1); j++)
            {
                bombCoordinates[i, j] = coordinates[j];
            }
        }

        return bombCoordinates;
    }

    private static void ExplodeBomb(int[,] matrix, int row, int col)
    {
        if (matrix[row, col] <= 0) return;

        int rowIterStart = Math.Max(row - 1, 0);
        int rowIterEnd = Math.Min(row + 1, matrix.GetLength(0) - 1);
        int colIterStart = Math.Max(col - 1, 0);
        int colIterEnd = Math.Min(col + 1, matrix.GetLength(1) - 1);
        int damage = matrix[row, col];

        for (int i = rowIterStart; i <= rowIterEnd; i++)
        {
            for (int j = colIterStart; j <= colIterEnd; j++)
            {
                if (matrix[i, j] > 0)
                {
                    matrix[i, j] -= damage;

                }

            }

        }
    }

    private static void PrintAnswer(int[,] matrix, int aliveCellsCount, int aliveCellsSum)
    {
        Console.WriteLine($"Alive cells: {aliveCellsCount}");
        Console.WriteLine($"Sum: {aliveCellsSum}");

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j > 0) Console.Write(" ");
                Console.Write(matrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}