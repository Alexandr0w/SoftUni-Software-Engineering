int n = int.Parse(Console.ReadLine());

double[][] matrix = new double[n][];
for (int i = 0; i < n; i++)
{
    matrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
}

