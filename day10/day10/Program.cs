var input = File.ReadLines($"{Environment.CurrentDirectory}/input.txt").ToList();

Calculator calculator = new Calculator();

foreach (var line in input)
{
    calculator.Add(line);
}

Console.WriteLine($"Result is : {calculator.GetResult()}");
