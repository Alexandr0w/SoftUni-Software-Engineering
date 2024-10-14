public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        char[,] matrix = ReadSquareMatrix(n);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == 'K')
                {

                }
            }
        }
    }

    private static int CountConficts(char[,] matrix, int row, int col)
    {

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