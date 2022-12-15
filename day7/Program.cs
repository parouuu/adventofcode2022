using System.Text.RegularExpressions;
using System.Xml.Linq;

var input = File.ReadLines($"{Environment.CurrentDirectory}/input.txt").ToList();

Regex cdRegex = new Regex(@"\$\s+(cd)\s+(.+)", RegexOptions.IgnoreCase);
Regex dirRegex = new Regex(@"(dir)\s+(\w+)", RegexOptions.IgnoreCase);
Regex lsRegex = new Regex(@"\$\s?ls\s?", RegexOptions.IgnoreCase);
Regex fileRegex = new Regex(@"(\d+)\s+(.+)", RegexOptions.IgnoreCase);

var home = new DeviceDirectory()
{
    Name = "/"
};

// Console.WriteLine(match.Groups[0]);

DeviceDirectory current = home;

foreach (var line in input)
{
    var match = cdRegex.Match(line);
    if (match.Success)
    {
        var value = match.Groups[2].Value;

        if (value == "..")
        {
            current = current.Parent;
        }
        else
        {
            var dir = current.DirList.First(e => e.Name == value);
            current = dir;
        }
    }

    match = dirRegex.Match(line);
    if (match.Success)
    {
        var value = match.Groups[2].Value;

        DeviceDirectory dir = new DeviceDirectory
        {
            Name = value,
            Parent = current,
        };
        current.DirList.Add(dir);
    }

    match = lsRegex.Match(line);
    if (match.Success)
    {
    }

    match = fileRegex.Match(line);
    if (match.Success)
    {
        var value1 = match.Groups[1].Value;
        var value2 = match.Groups[2].Value;

        DeviceFile file = new DeviceFile
        {
            Name = value2,
            Size = Convert.ToInt32(value1),
        };
        current.FileList.Add(file);
    }
}

var dirOkList = new List<DeviceDirectory>();

var requiredSpace = 30_000_000 - (70_000_000 - home.GetSize());

int result = 70_000_000;

int ret = GoThroughDirs(home, requiredSpace, ref result);

Console.WriteLine($"Total size = {home.GetSize()} ({home.GetSize() - requiredSpace})");
Console.WriteLine($"Required space = {requiredSpace}");
Console.WriteLine($"Result = {result}");

int test = 0;

static int GoThroughDirs(DeviceDirectory directory, int requiredSpace, ref int result)
{
    int val = 0;

    foreach (var dir in directory.DirList)
    {
        val += GoThroughDirs(dir, requiredSpace, ref result);
    }

    val += directory.GetSize();

    if (directory.GetSize() >= requiredSpace && directory.GetSize() < result)
    {
        Console.WriteLine($"Setting dir {directory.Name} ({directory.GetSize()}) as target for deletion");
        result = directory.GetSize();
    }

    return val;
}