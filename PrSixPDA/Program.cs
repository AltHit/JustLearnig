using System.Diagnostics;
Random rand = new();

//#1
//Input is a numsTask1.txt file with words. Output words of an odd lenght

StreamReader numsTask1 = new("numsTask1.txt");
List<string> firInput = new(numsTask1.ReadToEnd().Split());

foreach (var x in firInput)
{
    if(x.Length % 2 != 0)
        Console.WriteLine(x);
}


//#2
//Input is a numsTask2.txt file with words in a column. Output words in a single string, separated with spaces

StreamReader numsTask2 = new("numsTask2.txt");
List<string> secInput = new(numsTask2.ReadToEnd().Split());

foreach (var x in secInput)
{
    Console.Write(x + " ");
}


//#3
//Number is given. Define if the number is even and a multiply of 10

int thirdInput = Convert.ToInt32(Console.ReadLine());
if (thirdInput % 2 == 0 && thirdInput % 10 == 0)
{
    Console.WriteLine("Number is even and a multiply of 10");
}
else{Console.WriteLine("Number is odd or isn't a multiply of 10");}


//#4
//User inputs positive numbers. Define sum of numbers divided by 'a' number. If the input is negative - shutdown

int fourthInput = Convert.ToInt32(Console.ReadLine());
int fourthSum = 0;

while (fourthInput >= 0)
{
    fourthSum += Convert.ToInt32(fourthInput);
    fourthInput = Convert.ToInt32(Console.ReadLine());
}
//if(fourthInput < 0){Process.Start("shutdown","/s /t 0");} //Shutting down on negative input

Console.WriteLine(fourthSum);


//#5
//Input is a rectangular matrix with n lines and m columns. This matrix consists of zeros and ones. Add new column to the matrix so all ones in lines will be even

Console.WriteLine("Enter the number of columns");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the number of lines");
int n = Convert.ToInt32(Console.ReadLine());

int[,] matrix = new int[n,m];
int[,] matrixNeo = new int[n,m+1];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        matrix[i, j] = rand.Next(0, 2);
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        matrixNeo[i, j] = matrix[i,j];
    }
}

for (int i = 0; i < n; i++)
{
    int counter = 0;
    for (int j = 0; j < m; j++)
    {
        counter += matrixNeo[i,j];
    }

    if (counter % 2 != 0)
    {
        matrixNeo[i, m] = 1;
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m + 1; j++)
    {
        Console.Write(matrixNeo[i,j] + " ");
    }
    Console.WriteLine();
}


//#6
//Input is an array with random amount of float numbers. Build 2 new arrays, one should contain only positive numbers and the other - only negative

int size = rand.Next(0, 100);
double[] sixArr = new double[size];
double[] yin = new double[size];
double[] yang = new double[size];

for (int i = 0; i < sixArr.Length; i++)
{
    sixArr[i] = rand.Next(-100, 101);
    sixArr[i] += rand.NextDouble();
}

for (int i = 0; i < size; i++)
{
    if (sixArr[i] > 0)
    {
        yin[i] = sixArr[i];
    }
    else
    {
        yang[i] = sixArr[i];
    }
}

Console.WriteLine("Positive elements are");
foreach (var x in yin)
{
    if(x != 0)
        Console.WriteLine(x);
}

Console.WriteLine("Negative elements are");
foreach (var x in yang)
{
    if(x != 0)
        Console.WriteLine(x);
}