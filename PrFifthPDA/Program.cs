using System.Globalization;
using System.Text;

//#1
//Input is a numsTask1.txt file with int numbers. Find the product of elements after minimal

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


//#2
//Input is a numsTask2.txt file with float numbers divided with ;. Sort numbers and write sorted numbers back into file

StreamReader numsTask2 = new("numsTask2.txt");

string[] secInput = numsTask2.ReadToEnd().Split(";");
double[] secConverted = new double[secInput.Length];
numsTask2.Close();
for (int i = 0; i < secInput.Length; i++)
{
    secConverted[i] = Convert.ToDouble(secInput[i]);
}

Array.Sort(secConverted);
string secText = "";

foreach (double x in secConverted)
{
    secText = secText + Convert.ToString(x, CultureInfo.CurrentCulture) + ";";
}

await using (FileStream secOut = new FileStream("numsTask2.txt", FileMode.OpenOrCreate))
{
    byte[] buffer = Encoding.Default.GetBytes(secText);
    await secOut.WriteAsync(buffer, 0, buffer.Length);
}


//#3
//Input is a numsTask3.txt file with ints. Find average number before minimal element

StreamReader numsTask3 = new("numsTask3.txt");

string[] thirdInput = numsTask3.ReadToEnd().Split();
int thirdAvg = 0,
    thirdMin = Convert.ToInt32(thirdInput[0]),
    thirdMinIndex = 0;

for(int i = 0; i < thirdInput.Length; i++)
{
    if (Convert.ToInt32(thirdInput[i]) < thirdMin)
    {
        thirdMin = Convert.ToInt32(thirdInput[i]);
        thirdMinIndex = i;
    }
}

for(int i = 0; i < thirdMinIndex; i++)
{
    thirdAvg += Convert.ToInt32(thirdInput[i]);
}

Console.WriteLine($"Average before minimal element is {thirdAvg/thirdMinIndex}");


//#4
//Input is a numsTask4.txt with ints. Find sum of all elements different from maximal by 1

StreamReader numsTask4 = new("numsTask4.txt");

string[] fourthInput = numsTask4.ReadToEnd().Split();
int fourthSum = 0,
    fourthMax = Convert.ToInt32(fourthInput[0]);

foreach (var t in fourthInput)
{
    if (Convert.ToInt32(t) > fourthMax)
    {
        fourthMax = Convert.ToInt32(t);
    }
}

foreach (var t in fourthInput)
{
    if (Math.Abs(fourthMax - Convert.ToInt32(t)) >= 1)
    {
        fourthSum += Convert.ToInt32(t);
    }
}

Console.WriteLine($"Sum of all differentiating elements is {fourthSum}");


//#5
//Input is again numsTask5.txt with ints. Find average between minimal and maximal elements

StreamReader numsTask5 = new("numsTask5.txt");

string[] fifthInput = numsTask5.ReadToEnd().Split();
int fifthAvg = 0,
    fifthMax = Convert.ToInt32(fifthInput[0]),
    fifthMin = Convert.ToInt32(fifthInput[0]),
    fifthMaxIndex = 0,
    fifthMinIndex = 0;

for(int i = 0; i < fifthInput.Length; i++)
{
    if (Convert.ToInt32(fifthInput[i]) < fifthMin)
    {
        fifthMin = Convert.ToInt32(fifthInput[i]);
        fifthMinIndex = i;
    }
}

for(int i = 0; i < fifthInput.Length; i++)
{
    if (Convert.ToInt32(fifthInput[i]) > fifthMax)
    {
        fifthMax = Convert.ToInt32(fifthInput[i]);
        fifthMaxIndex = i;
    }
}

for(int i = fifthMinIndex + 1; i < fifthMaxIndex; i++)
{
    fifthAvg += Convert.ToInt32(fifthInput[i]);
}

Console.WriteLine(fifthMinIndex);
Console.WriteLine(fifthMaxIndex);
Console.WriteLine(fifthAvg);

Console.WriteLine($"Sum of all differentiating elements is {fifthAvg/(fifthMaxIndex - fifthMinIndex - 1)}");
