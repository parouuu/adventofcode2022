﻿var input = File.ReadLines($"{Environment.CurrentDirectory}/input.txt").ToList();

static int IsCoveredLeft(int[] treeArray, int y, int depth = 1)
{
    if (y + 1 == depth)
        return depth - 1;

    int current = treeArray[y];

    if (treeArray[y - depth] < current)
        return IsCoveredLeft(treeArray, y, depth  + 1);

    return depth;
}

static int IsCoveredRight(int[] treeArray, int y, int depth = 1)
{
    if (treeArray.Length - y == depth)
        return depth - 1;

    int current = treeArray[y];

    if (treeArray[y + depth] < current)
        return IsCoveredRight(treeArray, y, depth + 1);

    return depth;
}

static int IsCoveredTop(int[][] treeArray, int i, int y, int depth = 1)
{
    if (i + 1 == depth)
        return depth - 1;

    int current = treeArray[i][y];

    if (treeArray[i - depth][y] < current)
        return IsCoveredTop(treeArray, i, y, depth + 1);

    return depth;
}

static int IsCoveredBottom(int[][] treeArray, int i, int y, int depth = 1)
{
    if (treeArray[i].Length - i == depth)
        return depth - 1;

    int current = treeArray[i][y];

    if (treeArray[i + depth][y] < current)
        return IsCoveredBottom(treeArray, i, y, depth + 1);

    return depth;
}
 
var treeArray = BuildForest(input);
int result = 0;

for (int i = 1; i < treeArray.Count() - 1; i++)
{
    for (int y = 1; y < treeArray.Count() - 1; y++)
    {
        var left = IsCoveredLeft(treeArray[i], y);
        var right = IsCoveredRight(treeArray[i], y);
        var top = IsCoveredTop(treeArray, i, y);
        var bottom = IsCoveredBottom(treeArray, i, y);

        var total = left * right * bottom * top;
        if (total > result)
            result = total;
    }
}

Console.WriteLine($"Count: {result}");


static int[][] BuildForest(List<string> input)
{
    var treeArray = new int[99][];

    int i = 0;
    foreach (var line in input)
    {
        treeArray[i] = line.Select(c => Convert.ToInt32(c.ToString())).ToArray();
        i++;
    }

    return treeArray;
}