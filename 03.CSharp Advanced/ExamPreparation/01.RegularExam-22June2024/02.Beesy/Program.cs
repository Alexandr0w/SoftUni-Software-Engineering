int n = int.Parse(Console.ReadLine());

char[,] matrix = new char[n, n];

int beeRow = 0;
int beeCol = 0;

for (int i = 0; i < n; i++)
{
    string rowInput = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = rowInput[j];
        if (rowInput[j] == 'B')
        {
            beeRow = i;
            beeCol = j;
        }
    }
}

int nectar = 0;
int energy = 15;
bool canRestore = true;
bool isHiveReached = false;

while (true)
{
    matrix[beeRow, beeCol] = '-';

    energy--;

    string command = Console.ReadLine();

    switch (command)
    {
        case "down":
            beeRow++;
            if (beeRow == matrix.GetLength(0))
            {
                beeRow = 0;
            }
            break;
        case "right":
            beeCol++;
            if (beeCol == matrix.GetLength(1))
            {
                beeCol = 0;
            }
            break;
        case "up":
            beeRow--;
            if (beeRow == -1)
            {
                beeRow = matrix.GetLength(0) - 1;
            }
            break;
        case "left":
            beeCol--;
            if (beeCol == -1)
            {
                beeCol = matrix.GetLength(1) - 1;
            }
            break;
    }

    if (Char.IsDigit(matrix[beeRow, beeCol]))
    {
        nectar += int.Parse(matrix[beeRow, beeCol].ToString());
    }
    else if (matrix[beeRow, beeCol] == 'H')
    {
        isHiveReached = true;
        break;
    }

    if (energy <= 0)
    {
        if (nectar <= 30 || !canRestore)
        {
            break;
        }
        else
        {
            energy += nectar - 30;
            nectar = 30;
            canRestore = false;
        }
    }
}

if (isHiveReached && nectar >= 30)
{
    Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {energy}");
}
else if (isHiveReached)
{
    Console.WriteLine($"Beesy did not manage to collect enough nectar.");
}
else
{
    Console.WriteLine($"This is the end! Beesy ran out of energy.");
}

matrix[beeRow, beeCol] = 'B';
PrintMatrix(matrix);


static void PrintMatrix(char[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j]);
        }
        Console.WriteLine();
    }
}
