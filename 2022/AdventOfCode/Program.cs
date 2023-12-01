IEnumerable<string> text = File.ReadLines("""C:\Users\StéphaneVEREZ\source\repos\AdventOfCode\input.txt""");

List<int> biggestList = new List<int>(3)
{
    0, 0, 0
};

int sum = 0;

foreach (var line in text)
{
    if (int.TryParse(line, out int value))
    {
        sum += value;
    }
    else
    {
        if (biggestList.Any(number => number < sum))
        {
            biggestList.Add(sum);
            biggestList = biggestList.OrderByDescending(number => number).Take(3).ToList();
        }
        sum = 0;
    }
}

Console.WriteLine(biggestList.Sum());
