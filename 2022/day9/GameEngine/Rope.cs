public class Rope
{
    public List<RopePart> KnotList = new List<RopePart>()
    {
        new RopePart(),new RopePart(),new RopePart(),new RopePart(),new RopePart(),new RopePart(),new RopePart(),new RopePart(),new RopePart(),new RopePart()
    };
    public Dictionary<Direction, Action> DirectionDictionary { get; private set; }
    List<Coord> CoordHistory = new List<Coord>();

    public Rope()
    {
        var head = KnotList.First();
        var tail = KnotList.Last();
        CoordHistory.Add(new Coord(tail.Coord.X, tail.Coord.Y));

        DirectionDictionary = new Dictionary<Direction, Action>
        {
            { Direction.Left, head.MoveLeft },
            { Direction.Right, head.MoveRight },
            { Direction.Up, head.MoveUp },
            { Direction.Down, head.MoveDown }
        };
    }

    public void Move(Direction direction)
    {
        DirectionDictionary[direction]();

        RopePart previousKnot = KnotList.First();
        RopePart tail = KnotList.Last();

        foreach (var knot in KnotList.Skip(1))
        {
            if (!knot.IsInRangeOf(previousKnot))
            {
                knot.GetCloserTo(previousKnot);
            }
            previousKnot = knot;
        }

        if (!CoordHistory.Any(coord => coord.X == tail.Coord.X && coord.Y == tail.Coord.Y))
        {
            CoordHistory.Add(new Coord(tail.Coord.X, tail.Coord.Y));
        }
    }

    public int GetTailPositionCount() => CoordHistory.Count();

    internal void DrawPath()
    {
        const int squareSize = 100;
        const int minX = -squareSize;
        const int maxX = squareSize;
        const int minY = -squareSize;
        const int maxY = squareSize;

        for (int y = maxY; y >= minY; y--)
        {
            for (int x = minX; x <= maxX; x++)
            {
                if (CoordHistory.Any(c => c.X == x && c.Y == y))
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.Write('\n');
        }
    }
}
