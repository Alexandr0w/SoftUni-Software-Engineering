//Input
string eggsSize = Console.ReadLine();
string eggsColor = Console.ReadLine();
int batches = int.Parse(Console.ReadLine());

//Solution
int pricePerBatch = 0;
switch (eggsSize)
{
    case "Large":
        switch (eggsColor)
        {
            case "Red": pricePerBatch = 16; break;
            case "Green": pricePerBatch = 12; break;
            case "Yellow": pricePerBatch = 9; break;
        }
        break;
    case "Medium":
        {
            switch (eggsColor)
            {
                case "Red": pricePerBatch = 13; break;
                case "Green": pricePerBatch = 9; break;
                case "Yellow": pricePerBatch = 7; break;
            }
        }
        break;
    case "Small":
        switch (eggsColor)
        {
            case "Red": pricePerBatch = 9; break;
            case "Green": pricePerBatch = 8; break;
            case "Yellow": pricePerBatch = 5; break;
        }
        break;
}

int totalIncome = pricePerBatch * batches;
double expenses = totalIncome * 0.35;
double netIncome = totalIncome - expenses;

Console.WriteLine($"{netIncome:F2} leva.");