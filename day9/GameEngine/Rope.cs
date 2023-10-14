public partial class Rope
{
    public RopePart Head { get; private set; }
    public RopePart Tail { get; private set; }
    public Dictionary<Direction, Action> DirectionDictionary { get; private set; }
    List<Coord> CoordHistory = new List<Coord>();

    public Rope()
    {
        Head = new RopePart(RopePartType.Head);
        Tail = new RopePart(RopePartType.Tail);

        CoordHistory.Add(new Coord(Tail.Coord.X, Tail.Coord.Y));

        DirectionDictionary = new Dictionary<Direction, Action>
        {
            { Direction.Left, Head.MoveLeft },
            { Direction.Right, Head.MoveRight },
            { Direction.Up, Head.MoveUp },
            { Direction.Down, Head.MoveDown }
        };
    }

    public void Move(Direction direction)
    {
        DirectionDictionary[direction]();

        if (!Tail.IsInRangeOf(Head))
        {
            Tail.GetCloserTo(Head);

            if (!CoordHistory.Any(coord => coord.X == Tail.Coord.X && coord.Y == Tail.Coord.Y))
            {
                CoordHistory.Add(new Coord(Tail.Coord.X, Tail.Coord.Y));
            }
        }
    }

    public int GetTailPositionCount() => CoordHistory.Count();

    internal void DrawPath()
    {
        int minX = -150;//CoordHistory.Min(c => c.X);
        int maxX = 12;//CoordHistory.Max(c => c.X);
        int minY = -60;//CoordHistory.Min(c => c.Y);
        int maxY = 22;//CoordHistory.Max(c => c.Y);

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
