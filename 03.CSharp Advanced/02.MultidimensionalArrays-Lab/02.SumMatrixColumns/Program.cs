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

<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
<<<<<<< HEAD
>>>>>>> 17fcfae343c7893ee25c3c2474fb76d30280635d
for(int j = 0; j < cols; j++) // Iterate all columns
{
    int sum = 0;
    for (int i = 0; i < rows; i++) // Iterate all rows for j-th column
    {
        sum += matrix[i, j];
=======
<<<<<<< HEAD
=======
>>>>>>> 48d7ae599d31b28b2513dc57f8172fcb65822ad4
>>>>>>> 17fcfae343c7893ee25c3c2474fb76d30280635d
for(int col = 0; col < cols; col++) // Iterate all columns
{
    int sum = 0;
    for (int row = 0; row < rows; row++) // Iterate all rows for j-th column
    {
        sum += matrix[row, col];
<<<<<<< HEAD
>>>>>>> b020bf8e4ab157908cb27d39617a106eac4af29f
=======
<<<<<<< HEAD
=======
>>>>>>> b020bf8e4ab157908cb27d39617a106eac4af29f
>>>>>>> 48d7ae599d31b28b2513dc57f8172fcb65822ad4
>>>>>>> 17fcfae343c7893ee25c3c2474fb76d30280635d
    }
    
    Console.WriteLine(sum);
}
