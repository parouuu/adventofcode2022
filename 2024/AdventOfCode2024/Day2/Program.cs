List<string> input = File.ReadLines($"{Environment.CurrentDirectory}/input.txt").ToList();

int safeReportCount = 0;

foreach (string line in input)
{
    int[] levels = line.Split(' ').Select(int.Parse).ToArray();
    bool isSafe = true;
    bool isDesc = levels[0] >= levels[1];

    for (int i = 0; i < levels.Length - 1; i++)
    {
        int sign = isDesc ? 1 : -1;
        int diff = sign * (levels[i] - levels[i + 1]);

        if (diff < 1 || diff > 3)
        {
            isSafe = false;
            break;
        }
    }
    Console.WriteLine($"Is safe: {isSafe}");
    safeReportCount += isSafe ? 1 : 0;
}

Console.WriteLine($"Result: {safeReportCount}");