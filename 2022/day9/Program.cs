var input = File.ReadLines($"{Environment.CurrentDirectory}/input.txt").ToList();

Rope rope = new Rope();

foreach (var line in input)
{
    string[] chars = line.Split(' ');

	Direction dir = Direction.Up;
	switch (chars[0])
	{
		case "R": dir = Direction.Right; break;
		case "L": dir = Direction.Left; break;
		case "U": dir = Direction.Up; break;
		case "D": dir = Direction.Down; break;
	}

	int iteration = Convert.ToInt32(chars[1]);

	for (int i = 0; i < iteration; i++)
	{
		rope.Move(dir);
	}
	//Console.WriteLine($"{dir} - {iteration}");
}

Console.WriteLine($"Result : {rope.GetTailPositionCount()}");

rope.DrawPath();
