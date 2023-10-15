internal class Calculator
{
    public int CycleNumber { get; set; }
    public int TotalValue { get; set; }
    public int Result { get; set; }

    List<int> CountedCycles = new List<int> { 20, 60, 100, 140, 180, 220 , 10000000 };
    public int NextCycle { get; set; }

    public Calculator()
    {
        TotalValue = 1;
        Result = 0;
        NextCycle = CountedCycles.First();
    }

    internal void Add(string line)
    {
        if (line == "noop")
        {
            CycleNumber++;
        }
        else
        {
            CycleNumber += 2;
        }

        if (NextCycle <= CycleNumber)
        {
            Result += TotalValue * NextCycle;

            NextCycle = CountedCycles.Where(x => x > NextCycle).FirstOrDefault();
        }

        if (line != "noop")
        {
            var number = default(int);
            int.TryParse(line.Split(' ')[1], out number);
            TotalValue += number;
        }
    }

    internal int GetResult() => Result;
}