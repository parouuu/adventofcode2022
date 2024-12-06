List<string> input = File.ReadLines($"{Environment.CurrentDirectory}/input.txt").ToList();


List<int> listOne = new();
List<int> listTwo = new();

foreach (string str in input)
{
    var strSplit = str.Split("   ");
    listOne.Add(int.Parse(strSplit[0]));
    listTwo.Add(int.Parse(strSplit[1]));
}

listOne.Sort();
listTwo.Sort();

int sum = 0;
for (int i = 0; i < listOne.Count; i++)
{
    sum += Math.Abs(listOne[i] - listTwo[i]);
}

Console.WriteLine(sum);