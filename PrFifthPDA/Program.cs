//#1
//Input is a numsTask1.txt file with int numbers. Find the product of elements after minimal
/*
StreamReader numsTask1 = new("numsTask1.txt");

string[] firInput = numsTask1.ReadToEnd().Split();
int firProd = 1,
    firMin = Convert.ToInt32(firInput[0]),
    firMinIndex = 0;

for(int i = 0; i < firInput.Length; i++)
{
    if (Convert.ToInt32(firInput[i]) < firMin)
    {
        firMin = Convert.ToInt32(firInput[i]);
        firMinIndex = i;
    }
}

for(int i = firMinIndex + 1; i < firInput.Length; i++)
{
    firProd *= Convert.ToInt32(firInput[i]);
}

Console.WriteLine($"Prod of all numbers after minimal is {firProd}");
*/

//#2
//Input is a numsTask2.txt file with float numbers divided with ;. Sort numbers and write sorted numbers back into file

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
