//#1
//Input is a positive number n. Find product of natural numbers multiples to 3 and beyond n
/*
Console.WriteLine("Enter the N-number");
int n = Convert.ToInt32(Console.ReadLine());
int prod = 1;
for (int i = 3; i <= n; i += 3)
    prod *= i;
Console.WriteLine(prod);
*/

//#2
//Input is a numsTask2.txt file with float numbers divided with ;. Find the sum of all positive numbers until finding a zero
/*
StreamReader numsTask2 = new("numsTask2.txt");

string[] secInput = numsTask2.ReadToEnd().Split(";");
double secSum = 0;

foreach (string inp in secInput)
{
    if (Convert.ToDouble(inp) == 0)
    {
        break;
    }

    if (Convert.ToDouble(inp) > 0)
    {
        secSum += Convert.ToDouble(inp);
    }
}

Console.WriteLine($"Sum of all positive numbers is {secSum}");
*/

//#3
//Input is a numsTask3.txt file with int numbers divided with ",". Find the ratio of maximal and minimal numbers until finding a zero
/*
StreamReader numsTask3 = new("numsTask3.txt");

string[] thirdInput = numsTask3.ReadToEnd().Split(",");
float thirdMin = Convert.ToInt32(thirdInput[0]);
float thirdMax = Convert.ToInt32(thirdInput[0]);

foreach (string inp in thirdInput)
{
    if (Convert.ToInt32(inp) == 0)
    {
//        Console.WriteLine(inp);
        break;
    }

    if (Convert.ToInt32(inp) < thirdMin)
    {
        thirdMin = Convert.ToInt32(inp);
//        Console.WriteLine("MIN!!!" + inp);
    }
    
    if (Convert.ToInt32(inp) > thirdMax)
    {
        thirdMax = Convert.ToInt32(inp);
//        Console.WriteLine("MAX!!!" + inp);
    }
}
//Console.WriteLine($"Just before min is {thirdMin} and max is {thirdMax}");
Console.WriteLine($"Ratio between maximal and minimal elements equals {thirdMin / thirdMax}");
*/

//#4
//Input is a numsTask4.txt file with int numbers divided with spaces. Find the number of similar numbers neighbouring each other
/*
StreamReader numsTask4 = new("numsTask4.txt");

string[] fourthInput = numsTask4.ReadToEnd().Split();
int fourthSim = 0;

for (int i = 1; i < fourthInput.Length; i++)
{
    if (fourthInput[i] == fourthInput[i - 1] || fourthInput[i] == fourthInput[i + 1])
    {
        fourthSim++;
    }
}

Console.WriteLine($"There are {fourthSim} similar numbers near by");
*/

//#5
//Input is 2 whole numbers a and b. Find if a point [a,b] is on area [-1,4;3,-2]
/*
Console.WriteLine("Enter number a");
double as = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter number b");
double bs = Convert.ToDouble(Console.ReadLine());

if(as is >= -1 and <= 3 && bs is <= 4 and >= -2)
{
    Console.WriteLine("Point IS in range");
}
else
{
    Console.WriteLine("Point IS NOT in range");
}
*/

//#6
//Input is 2 whole numbers a and b. Find if a point [a,b] is on area of a triangle

Console.WriteLine("Enter number a");
double at = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter number b");
double bt = Convert.ToDouble(Console.ReadLine());

