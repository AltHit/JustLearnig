int[] RandomestList(int lengthOfList, int startOfRandomnes, int endOfRandomnes)
{
    int[] output = new int[lengthOfList];
    Random rand = new Random();
    for (int x = 0; x < output.Length; x++)
    {
        output[x] = rand.Next(startOfRandomnes, endOfRandomnes);
    }
    return output;
}

//#1
//Array with 10 random numbers. Output minimal element

int[] randomNums = new int[10];
Random rand = new Random();
for (int i = 0; i < randomNums.Length; i++)
{
    randomNums[i] = rand.Next();
}

Array.Sort(randomNums);

Console.WriteLine(randomNums[0]);


//#2
//Add numbers to the list until input is 0. Output sum and product of all elements. Output middle element

List<int> secList = new List<int>();
int secInput, product = 1;
Console.WriteLine("Вводите список числел. По завершению ввода - введите 0");
do
{
    secInput = Convert.ToInt32(Console.ReadLine());
    secList.Add(secInput);
}
while(secInput != 0);

secList.RemoveAt(secList.Count - 1); //remove 0

Console.WriteLine("Now sum it up");
var sumOfList = secList.Sum();
Console.WriteLine(sumOfList);

Console.WriteLine("Now mult it up");
foreach (var t in secList)
{
    product *= t;
}
Console.WriteLine(product);

Console.WriteLine("Now make it average");
var listsAverage = secList.Average();
Console.WriteLine(listsAverage);


//#3
//input new elements in list until user inputs empty string. Output the shortest element

List<string?> thirdList = new List<string?>();
string? thirdInput;
Console.WriteLine("Вводите элементы. По завершению ввода - введите пустую строку");
do
{
    thirdInput = Console.ReadLine();
    thirdList.Add(thirdInput);
}
while(thirdInput != "");

thirdList.Sort();

Console.WriteLine("Print that short element");
Console.WriteLine(thirdList[1]);


//#4
//Create function that fills list with random numbers. Output list with special form of for

Console.WriteLine("Длинну случайного списка, начало случайного диапозона и его конец");
int lengthFour = Convert.ToInt32(Console.ReadLine());
int startFour = Convert.ToInt32(Console.ReadLine());
int endFour = Convert.ToInt32(Console.ReadLine());
int[] arrNumFour = new int[lengthFour];
arrNumFour = RandomestList(lengthFour, startFour, endFour);
foreach (var g in arrNumFour)
{
    Console.WriteLine(g);
}


//#5
//Count words inside of a string. Insert Start in the start of a string and End at the end of it

Console.WriteLine("Введите текст в виде строки, разделяемой пробелами");
string? textFive = Console.ReadLine();
int wordCounter = 0, index = 0;
textFive = textFive.Insert(0, "Start ");
textFive = textFive.Insert(textFive.Length, " End");
Console.WriteLine(textFive);
while (index < textFive.Length && char.IsWhiteSpace(textFive[index]))
    index++;

while (index < textFive.Length)
{
    while (index < textFive.Length && !char.IsWhiteSpace(textFive[index]))
        index++;

    wordCounter++;
    
    while (index < textFive.Length && char.IsWhiteSpace(textFive[index]))
        index++;
}

Console.WriteLine($"This text consists of {wordCounter} words");