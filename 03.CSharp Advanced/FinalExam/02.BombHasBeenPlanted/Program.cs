int[] dimensions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

const char CounterTerroristSymbol = 'C';
const char TerroristSymbol = 'T';
const char BombSymbol = 'B';
const char EmptySymbol = '*';
const char DefuseSymbol = 'D';
const char BombExplodeSymbol = 'X';


char[,] matrix = new char[rows, cols];

int counterTerroristRow = -1, counterTerroristCol = -1;
int bombRow = -1, bombCol = -1;

for (int i = 0; i < rows; i++)
{
    string line = Console.ReadLine();
    for (int j = 0; j < cols; j++)
    {
        matrix[i, j] = line[j];

        if (matrix[i, j] == CounterTerroristSymbol)
        {
            counterTerroristRow = i;
            counterTerroristCol = j;
        }
        if (matrix[i, j] == BombSymbol)
        {
            bombRow = i;
            bombCol = j;
        }
    }
}

int timeLeft = 16;
int initialRow = counterTerroristRow;
int initialCol = counterTerroristCol;
bool gameOver = false;
bool bombExploded = false;

string command;
while (!gameOver && timeLeft > 0 && (command = Console.ReadLine()) != null)
{
    if (command == "left")
    {
        Move(ref counterTerroristRow, ref counterTerroristCol, 0, -1, rows, cols, ref timeLeft);
    }
    else if (command == "right")
    {
        Move(ref counterTerroristRow, ref counterTerroristCol, 0, 1, rows, cols, ref timeLeft);
    }
    else if (command == "up")
    {
        Move(ref counterTerroristRow, ref counterTerroristCol, -1, 0, rows, cols, ref timeLeft);
    }
    else if (command == "down")
    {
        Move(ref counterTerroristRow, ref counterTerroristCol, 1, 0, rows, cols, ref timeLeft);
    }
    else if (command == "defuse")
    {
        if (counterTerroristRow == bombRow && counterTerroristCol == bombCol)
        {
            timeLeft -= 4;
            if (timeLeft >= 0)
            {
                Console.WriteLine("Counter-terrorist wins!");
                Console.WriteLine($"Bomb has been defused: {timeLeft} second/s remaining.");
                matrix[bombRow, bombCol] = DefuseSymbol;
                gameOver = true;
            }
            else
            {
                bombExploded = true;
                Console.WriteLine("Terrorists win!");
                Console.WriteLine("Bomb was not defused successfully!");
                Console.WriteLine($"Time needed: {Math.Abs(timeLeft)} second/s.");
                matrix[bombRow, bombCol] = BombExplodeSymbol;
                gameOver = true;
            }
        }
        else
        {
            timeLeft -= 2;
        }
    }

    if (matrix[counterTerroristRow, counterTerroristCol] == TerroristSymbol)
    {
        Console.WriteLine("Terrorists win!");
        matrix[counterTerroristRow, counterTerroristCol] = EmptySymbol;
        gameOver = true;
    }

    if (timeLeft <= 0 && !gameOver)
    {
        bombExploded = true;
        Console.WriteLine("Terrorists win!");
        Console.WriteLine("Bomb was not defused successfully!");
        Console.WriteLine("Time needed: 0 second/s.");
        matrix[bombRow, bombCol] = BombSymbol;
        gameOver = true;
    }
}

matrix[initialRow, initialCol] = CounterTerroristSymbol;

PrintMatrix(matrix);

static void Move(ref int row, ref int col, int rowChange, int colChange, int rows, int cols, ref int timeLeft)
{
    int newRow = row + rowChange;
    int newCol = col + colChange;

    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
    {
        row = newRow;
        col = newCol;
    }

    timeLeft--; 
}

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