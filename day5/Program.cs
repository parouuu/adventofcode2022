/*
    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2
*/

List<string> input = File.ReadLines("""C:\Git\adventofcode2022\day5\input.txt""").ToList();

var crates = GetCrates(input);

var instructionLines = input.Where(str => str.TrimStart().StartsWith("move ")).ToList();

foreach (var line in instructionLines)
{
    var strblocks = line.Split(" ").Where(x => int.TryParse(x, out _)).Select(x => Convert.ToInt32(x)).ToList();

    int number = strblocks[0];
    int origin = strblocks[1] - 1;
    int target = strblocks[2] - 1;

    var list = new List<string>();
    for (int i = 0; i < number; i++)
    {
        if (crates[origin].Any())
        {

            var value = crates[origin].Pop();
            list.Add(value);
        }
    }
    list.Reverse();
    list.ForEach(crates[target].Push);
}

crates.ForEach(x =>
{
    if (x.Any())
        Console.Write(x.Pop());
});

static List<Stack<string>> GetCrates(List<string> input)
{
    var crates = new List<Stack<string>>() { new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>() };
    var crateLines = input.Where(x => x.TrimStart().StartsWith("[")).Reverse().ToList();

    foreach (var str in crateLines)
    {
        if (str[1].ToString() != " ")
            crates[0].Push(str[1].ToString());
        if (str[5].ToString() != " ")
            crates[1].Push(str[5].ToString());
        if (str[9].ToString() != " ")
            crates[2].Push(str[9].ToString());

        if (str[13].ToString() != " ")
            crates[3].Push(str[13].ToString());
        if (str[17].ToString() != " ")
            crates[4].Push(str[17].ToString());
        if (str[21].ToString() != " ")
            crates[5].Push(str[21].ToString());
        if (str[25].ToString() != " ")
            crates[6].Push(str[25].ToString());
        if (str[29].ToString() != " ")
            crates[7].Push(str[29].ToString());
        if (str[33].ToString() != " ")
            crates[8].Push(str[33].ToString());
    }
    return crates;
}
