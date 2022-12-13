
/*
 *    mjqjpqmgbljsphdztnvjfqwrcgsmlb
 */

string input = File.ReadLines("""C:\Git\adventofcode2022\day6\input.txt""").ToList().First();

bool found = true;
for (int i = 0; i + 14 < input.Count(); i++)
{
    var str = input.Substring(i, 14);
    found = true;
    foreach (char c in str)
    {
        if (str.Count(s => s == c) >= 2)
        {
            found = false;
        }
    }
    if (found)
    {
        Console.WriteLine(i + 14);
    }
}