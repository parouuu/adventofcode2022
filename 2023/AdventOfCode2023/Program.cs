var input = File.ReadLines($"{Environment.CurrentDirectory}/input.txt").ToList();

int result = 0;

string[] digitAsStrings = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

foreach (string value in input)
{
    int firstValue = GetFirstValue(value);
    int lastValue = GetLastValue(value);

    string concatString = firstValue.ToString() + lastValue.ToString();
    Console.WriteLine(value + " => " + concatString);

    result += Convert.ToInt32(concatString);
    Console.WriteLine(result);
}

int GetFirstValue(string input)
{
    int result = 0;
    int arrayIndex = 0;
    int lowestIndex = 999999;

    foreach (string str in digitAsStrings)
    {
        int index = input.IndexOf(str.ToString());

        if (index != -1 && lowestIndex > index)
        {
            lowestIndex = index;

            if (!int.TryParse(input.Substring(index, 1), out result))
            {
                result = arrayIndex + 1;
            }
        }
        arrayIndex++;
    }

    return result;
}

int GetLastValue(string input)
{
    int result = 0;
    int arrayIndex = 0;
    int highestIndex = -1;

    foreach (string str in digitAsStrings)
    {
        int index = input.LastIndexOf(str.ToString());

        if (index != -1 && highestIndex < index)
        {
            highestIndex = index;

            if (!int.TryParse(input.Substring(index, 1), out result))
            {
                result = arrayIndex + 1;
            }
        }
        arrayIndex++;
    }

    return result;
}