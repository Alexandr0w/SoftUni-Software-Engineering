string studentName = Console.ReadLine();
int grade = 1;
double totalGrade = 0;
int excludedGrade = 0;

while (grade <= 12)
{
    double currentGrade = double.Parse(Console.ReadLine());

    if (currentGrade >= 4)
    {
        totalGrade += currentGrade;
        grade++;
    }
    else
    {
        excludedGrade = grade;
        Console.WriteLine($"{studentName} has been excluded at {excludedGrade} grade");
        return;
    }
}

double averageGrade = totalGrade / 12;
Console.WriteLine($"{studentName} graduated. Average grade: {averageGrade:f2}");