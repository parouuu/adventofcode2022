internal class Television
{
    string image = string.Empty;
    int actualCycle = 1;
    int X = 1;

    internal void Add(string line)
    {
        int cyclesToRun = 0;
        int value = 0;

        if (line == "noop")
        {
            cyclesToRun = 1;
        }
        else
        {
            cyclesToRun = 2;
            int.TryParse(line.Split(' ')[1], out value);
        }

        //Console.WriteLine($"{line}\t => Cycle: {actualCycle} / X: {X} / value: {value}");
        
        for (int i = 0; i < cyclesToRun; i++)
        {
            bool shouldDraw = Math.Abs(((actualCycle - 1) % 40) - X) <= 1;

            if (shouldDraw)
            {
                image += '#';
            }
            else
            {
                image += '.';
            }

            actualCycle++;

            if ((actualCycle - 1)% 40 == 0)
            {
                image += '\n';
            }
        }

        X += value;

    }

    public string GetImage() => image;
}