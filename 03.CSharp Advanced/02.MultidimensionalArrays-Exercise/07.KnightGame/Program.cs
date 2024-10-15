public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        char[,] matrix = ReadSquareMatrix(n);

        int removedKnights = 0;
        bool hasConflicts = true;
        while (hasConflicts)
        {
            int maxConflicts = 0;
            int maxConflictsRow = -1;
            int maxConflictsCol = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 'K')
                    {
                        int currentConflicts = CountConficts(matrix, i, j);

                        if (currentConflicts > maxConflicts)
                        {
                            maxConflicts = currentConflicts;
                            maxConflictsRow = i;
                            maxConflictsCol = j;
                        }
                    }
                }
            }
            if (maxConflicts == 0)
            {
                hasConflicts = false;
            }
            else
            { 
                matrix[maxConflictsRow, maxConflictsCol] = '0';
                removedKnights++;
            }
        }

        Console.WriteLine(removedKnights);
    }

    private static int[][] directions = { 
        new int[] { -2, 1 },
        new int[] { -1, 2 },
        new int[] { 1, 2 },
        new int[] { 2, 1 },
        new int[] { 2, -1 },
        new int[] { 1, -2 },
        new int[] { -1, -2 },
        new int[] { -2, -1 }
    };

    private static int CountConficts(char[,] matrix, int row, int col)
    {
        int conflicts = 0;
        foreach (int[] direction in directions)
        {
            int nextRow = row + direction[0];
            if (nextRow < 0 || nextRow >= matrix.GetLength(0)) continue;

            int nextCol = col + direction[1];
            if (nextCol < 0 || nextCol >= matrix.GetLength(1)) continue;

            if (matrix[nextRow, nextCol] == 'K') conflicts++;
        }

        return conflicts;
    }

    private static char[,] ReadSquareMatrix(int n)
    {
        char[,] matrix = new char[n, n];

        for (int i = 0; i < n; i++)
        {
            string data = Console.ReadLine();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = data[j];
            }
        }

        return matrix;
    }
}