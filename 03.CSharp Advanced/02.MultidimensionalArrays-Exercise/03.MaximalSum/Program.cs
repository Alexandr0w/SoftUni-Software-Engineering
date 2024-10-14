public class Program
{
    const int M = 3, N = 3;

    public static void Main()
    {
        int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int rows = dimensions[0];
        int cols = dimensions[1];

        int[,] matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = data[j];
            }
        }

        int rowIterEnd = rows - M + 1;
        int colIterEnd = cols - N + 1;
        int maxSum = int.MinValue;
        int maxOriginRow = -1;
        int maxOriginCol = -1;

        for (int i = 0; i < rowIterEnd; i++)
        {
            for (int j = 0; j < colIterEnd; j++)
            {
                int currentSum = SumSubMatrix(matrix, i, j);
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxOriginRow = i;
                    maxOriginCol = j;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");
        PrintSubMatrix(matrix, maxOriginRow, maxOriginCol);
    }

    private static int SumSubMatrix(int[,] matrix, int row, int col)
    {
        int sum = 0;
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                sum += matrix[row + i, col + j];
            }
        }

        return sum;
    }

    private static void PrintSubMatrix(int[,] matrix, int row, int col)
    {
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (j > 0) Console.Write(" ");
                Console.Write(matrix[row + i, col + j]);
            }

            Console.WriteLine();
        }
    }
}


