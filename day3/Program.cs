using day3;

List<string> input = File.ReadLines("""C:\Git\adventofcode2022\day3\input.txt""").ToList();

int totalQ1 = 0;
int totalQ2 = 0;

foreach (string line in input)
{
    totalQ1 += RuckSackAnalyzer.Analyze(line);
}

while (input.Count > 0)
{
    var inputs = input.Take(3).ToArray();
    totalQ2 += RuckSackAnalyzer.GetBadges(inputs);
    input.Remove(inputs[2]);
    input.Remove(inputs[1]);
    input.Remove(inputs[0]);
}


Console.WriteLine(totalQ1);
Console.WriteLine(totalQ2);
