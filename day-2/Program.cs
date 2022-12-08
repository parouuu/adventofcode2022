internal class Program
{
    static Dictionary<string, RpsEnum> mapping = new Dictionary<string, RpsEnum>()
        {
            { "A", RpsEnum.Rock },
            { "B", RpsEnum.Paper },
            { "C", RpsEnum.Scissor },
            { "X", RpsEnum.Rock },
            { "Y", RpsEnum.Paper },
            { "Z", RpsEnum.Scissor }
        };

    private static void Main(string[] args)
    {
        IEnumerable<string> input = File.ReadLines("""C:\Git\adventofcode2022\day-2\input.txt""");


        foreach (string line in input)
        {
            var splittedLine = line.Split(' ');

            var elf = mapping[splittedLine.First()];
            var hero = mapping[splittedLine.Last()];
        }

    }
}

enum RpsEnum
{
    Rock,
    Paper,
    Scissor
};