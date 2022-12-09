internal class Program
{
    static Dictionary<string, RpsEnum> mappingDictionnary = new Dictionary<string, RpsEnum>()
        {
            { "A", RpsEnum.Rock },
            { "B", RpsEnum.Paper },
            { "C", RpsEnum.Scissor },
            { "X", RpsEnum.Rock },
            { "Y", RpsEnum.Paper },
            { "Z", RpsEnum.Scissor }
        };

    static Dictionary<RpsEnum, RpsEnum> resultDictionnary = new Dictionary<RpsEnum, RpsEnum>()
        {
            { RpsEnum.Rock, RpsEnum.Paper },
            { RpsEnum.Paper, RpsEnum.Scissor },
            { RpsEnum.Scissor, RpsEnum.Rock },
        };

    private static void Main(string[] args)
    {
        IEnumerable<string> input = File.ReadLines("""C:\Git\adventofcode2022\day-2\input.txt""");

        int totalQ1 = 0;
        int totalQ2 = 0;
        foreach (string line in input)
        {
            var splittedLine = line.Split(' ');
            var elf = mappingDictionnary[splittedLine.First()];
            var hero = mappingDictionnary[splittedLine.Last()];

            QuestionOne(ref totalQ1, elf, hero);
            QuestionTwo(ref totalQ2, elf, splittedLine.Last());

        }
        Console.WriteLine($"Q1 : {totalQ1}");
        Console.WriteLine($"Q2 : {totalQ2}");
    }

    private static void QuestionTwo(ref int totalQ2, RpsEnum elf, string last)
    {
        totalQ2 = GetGameResultHeroScoreQ2(totalQ2, last);

        if (last == "Y")
            totalQ2 += (int)elf;
        else
        {
            int val = 0;
            if (last == "X")
                val = (int)elf - 1;
            else
                val = (int)elf + 1;

            if (val == 0)
                val = 3;
            else if (val == 4)
                val = 1;

            totalQ2 += val;
        }
    }

    private static int GetGameResultHeroScoreQ2(int totalQ2, string last)
    {
        switch (last)
        {
            case "X":
                totalQ2 += 0;
                break;
            case "Y":
                totalQ2 += 3;
                break;
            case "Z":
                totalQ2 += 6;
                break;
            default:
                break;
        }

        return totalQ2;
    }

    private static void QuestionOne(ref int totalQ1, RpsEnum elf, RpsEnum hero)
    {
        totalQ1 += (int)hero;
        totalQ1 += GetGameResultHeroScoreQ1(elf, hero);
    }

    private static int GetGameResultHeroScoreQ1(RpsEnum elf, RpsEnum hero)
    {
        if (elf == hero)
            return 3;
        else if (resultDictionnary[elf] == hero)
            return 6;
        else
            return 0;
    }
}

enum RpsEnum
{
    Rock = 1,
    Paper = 2,
    Scissor = 3,
};