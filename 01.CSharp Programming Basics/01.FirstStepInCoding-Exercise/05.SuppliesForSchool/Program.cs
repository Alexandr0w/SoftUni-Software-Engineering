double penPrice = 5.80;
double markerPrice = 7.20;
double prepPrice = 1.20;

int pen = int.Parse(Console.ReadLine());    
int marker = int.Parse(Console.ReadLine()); 
int prep = int.Parse(Console.ReadLine());   
int discount = int.Parse(Console.ReadLine());

double sum = penPrice * pen + markerPrice * marker + prepPrice * prep; // цена на всички материали
double discSum = sum - (sum * discount / 100); // цена с отстъпката

Console.WriteLine(discSum);
