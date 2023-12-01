/*
 * 
24-66,23-25
3-3,2-80
14-80,13-20
39-78,40-40
36-90,89-90
51-94,50-50
10-72,10-98
54-81,2-90
27-84,27-85

 */


List<string> input = File.ReadLines("""C:\Git\adventofcode2022\day4\input.txt""").ToList();

int countQ1 = 0;
int countQ2 = 0;
foreach (string line in input)
{
    string[] array = line.Split(',');

    int input1 = Convert.ToInt32(array[0].Split('-')[0]);
    int input2 = Convert.ToInt32(array[0].Split('-')[1]);
    int input3 = Convert.ToInt32(array[1].Split('-')[0]);
    int input4 = Convert.ToInt32(array[1].Split('-')[1]);

    if ((input1 >= input3 && input2 <= input4) || (input1 <= input3 && input2 >= input4))
        countQ1++;

    if (input2 >= input3 && input4 >= input1)
        countQ2++;
}

Console.WriteLine(countQ1);
Console.WriteLine(countQ2);
