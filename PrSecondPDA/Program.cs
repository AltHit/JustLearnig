Random rand = new();

static float[] Equalizer(float[,] month)
{
    float[] avgForMonth = new float[12];
    for(int i = 0; i < 12; i++)
    {
        float summOfTemps = 0;
        for(int j = 0; j < 30; j++)
        {
            summOfTemps += month[i, j];
        }
        avgForMonth[i] = summOfTemps / 30;
    }
    return avgForMonth;
}

Dictionary<string, float> TheGreatEqualizer(Dictionary<string, float[]> date)
{
    Dictionary<string, float> output = new();
    foreach(var x in date)
    {
        float summOfTemps = 0;
        for(int i = 0; i < 30; i++)
        {
            summOfTemps += x.Value[i];
        }
        output[x.Key] = summOfTemps / 30;
    }
    return output;
}

float[] FillClimate(string season)
{
    float[] tempsOfClimate = new float[30];
    switch (season)
    {
        case "Winter":
            for (int i = 0; i < 30; i++)
                tempsOfClimate[i] = rand.Next(-40, 5);
            break;

        case "Spring":
            for (int i = 0; i < 30; i++)
                tempsOfClimate[i] = rand.Next(-5, 20);
            break;

        case "Summer":
            for (int i = 0; i < 30; i++)
                tempsOfClimate[i] = rand.Next(5, 30);
            break;

        case "Autumn":
            for (int i = 0; i < 30; i++)
                tempsOfClimate[i] = rand.Next(-15, 10);
            break;

        default:
            for(int i = 0; i < 30; i++)
            {
                tempsOfClimate[i] = rand.Next();
            }
            break;
    }
    return tempsOfClimate;
}

//#1
//Create an array of a 100 elements size. Fill this array with elements in descending order by the step of 3

int[] intsFirst = new int[100];
for (int i = 0; i < intsFirst.Length; i++)
{
    intsFirst[i] = (intsFirst[i] - 3) * i;
}

foreach(int i in intsFirst)
{
    Console.WriteLine(i);
}


//#2
//Fill an array with odd numbers starting with 1

Console.WriteLine("Enter size of an array");
int oddSize = Convert.ToInt32(Console.ReadLine());
int[] oddSecond = new int[oddSize];
oddSecond[0] = 1;
for(int i = 1; i < oddSecond.Length; i++)
{
    oddSecond[i] = oddSecond[i-1] + 2;
}

foreach (int i in oddSecond)
{
    Console.WriteLine(i);
}


//#3
//Fill square n by n matrix so that first line and column will have 1 and every other one will have sum of left and top one from it

Console.WriteLine("Enter size of the matrix");
int thirdSize = Convert.ToInt32(Console.ReadLine());
int[,] square = new int[thirdSize, thirdSize];

for (int i = 0; i < thirdSize; i++) //initial filling
{
    square[0, i] = 1;
    square[i, 0] = 1;
}

for (int i = 1; i < thirdSize; i++) //inline cycle with adjusted numbers to only touch insides of a matrix
{
    for (int j = 1; j < thirdSize; j++)
    {
        square[i, j] = square[i - 1, j] + square[i, j - 1]; //i - 1 is left one and j - 1 is the top one
    }
}

for (int i = 0; i < thirdSize; i++)  //outputing matrix
{
    for(int j = 0; j < thirdSize; j++)
    {
        Console.Write(square[i, j] + " ");
    }
    Console.WriteLine("");
}


//#4
//Count average temp. for all year. Create 2D matrix 12 by 30 with random temp. in each day. Create a function to average all month temperature

float[,] calender = new float[12,30];

for(int i = 0; i < 12; i++)
{
    if(i == 11 || i <= 1) //winter cycle
    {
        for(int j = 0; j < 30; j++)
        calender[i,j] = rand.Next(-40, 5);
    }
    if (i>1 && i < 5) //spring cycle
    {
        for (int j = 0; j < 30; j++)
        calender[i, j] = rand.Next(-5, 20);
    }
    if (i > 4 && i < 8) //summer cycle
    {
        for (int j = 0; j < 30; j++)
        calender[i, j] = rand.Next(5, 30);
    }
    if (i > 7 && i < 11) //autumn cycle
    {
        for (int j = 0; j < 30; j++)
        calender[i, j] = rand.Next(-15, 10);
    }
}

float[] vessel = Equalizer(calender);
Array.Sort(vessel);
float vesselsAvg = vessel.Average();

Console.WriteLine($"Average temperature for the entire year is {vesselsAvg}°C");

//uncomment to output average temperature for each month
/*
for (int i = 0; i < 12; i++)
{
    Console.WriteLine($"Temperature for month number {i+1} is {vessel[i]}");
}
*/

/*
for (int i = 0; i < 12; i++)  //outputing entire matrix
{
    for (int j = 0; j < 30; j++)
    {
        Console.Write(calender[i, j] + " ");
    }
    Console.WriteLine("");
}
*/

//#5
//#4, but instead of arrays use Dictionary with name of the mouth as a key and array of temps as value

float summUp = 0;
Dictionary<string, float[]> greatCalender = new() 
{
    {"January", new float[30]},
    {"February", new float[30]},
    {"March", new float[30]},
    {"April", new float[30]},
    {"May", new float[30]},
    {"June", new float[30]},
    {"July", new float[30]},
    {"August", new float[30]},
    {"September", new float[30]},
    {"October", new float[30]},
    {"November", new float[30]},
    {"December", new float[30]}
};

greatCalender["January"] = FillClimate("Winter");
greatCalender["February"] = FillClimate("Winter");
greatCalender["March"] = FillClimate("Spring");
greatCalender["April"] = FillClimate("Spring");
greatCalender["May"] = FillClimate("Spring");
greatCalender["June"] = FillClimate("Summer");
greatCalender["July"] = FillClimate("Summer");
greatCalender["August"] = FillClimate("Summer");
greatCalender["September"] = FillClimate("Autumn");
greatCalender["October"] = FillClimate("Autumn");
greatCalender["November"] = FillClimate("Autumn");
greatCalender["December"] = FillClimate("Winter");

var storageForWether = TheGreatEqualizer(greatCalender);

foreach(var y in storageForWether)
{
    Console.WriteLine($"{y.Key}    {y.Value}");
}

foreach(var z in storageForWether)
{
    summUp += z.Value;
}

Console.WriteLine($"Average temperature for this year is {summUp / 12}°C");