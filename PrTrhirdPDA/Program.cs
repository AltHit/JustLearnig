//#1

StreamReader io = new("input.txt");
int[] ai = new int[10];
string rawInput = io.ReadLine();
ai = rawInput.Split(' ').Select(int.Parse).ToArray();
rawInput = io.ReadLine();
int n = Convert.ToInt32(rawInput);
int[,] tickets = new int[n, 6];
using (StreamWriter output = new("output.txt"))
{
    for (int i = 0; i < n; i++)
    {
        rawInput = io.ReadLine();
        var tempInput = rawInput.Split(' ').Select(int.Parse).ToArray();
        int match = tempInput.Intersect(ai).Count();
        if (match >= 3)
        {
            output.WriteLine("Lucky");
        }
        else
        {
            output.WriteLine("Unlucky");
        }
    }
}

//#2

StreamReader nums = new("nums.txt");
int[] secInput = nums.ReadToEnd().Split().Select(int.Parse).ToArray();
int[] secSum = new int[secInput.Length];

for(int i = 0; i < secInput.Length; i++)
{
    if (secInput[i] % 2 == 0)
        secSum[i] = secInput[i];
}

nums.Close();

using (StreamWriter output = new("nums.txt"))
{
    foreach(int i in secSum)
    {
        if(i != 0)
            output.Write(i + " ");
    }
}

//#3

StreamReader stream = new("numsTake2.txt");
int[] thirdInput = stream.ReadToEnd().Split(",").Select(int.Parse).ToArray();
int finale = 0;

for (int i = thirdInput.Length - 1; i >= 0; i--)
{
    int last = thirdInput[i];
    int min = last;
    int result = 0;
    for (int j = 0; j < i; j++)
    {
        int lastOfLast = thirdInput[j];
        if (last < lastOfLast)
        {
            min = last;
        }
        else
        {
            min = lastOfLast;
        }

        result = min * (i - j);
        if (result > finale)
        {
            finale = result;
        }
    }
}
Console.WriteLine(finale);