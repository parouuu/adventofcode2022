var input = File.ReadLines($"{Environment.CurrentDirectory}/input.txt").ToList();

Television television = new Television();

foreach (var line in input)
{
    television.Add(line);
}

Console.WriteLine(television.GetImage());