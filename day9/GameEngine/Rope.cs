using System;
using System.Collections.Generic;

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

        DirectionDictionary = new Dictionary<Direction, Action>
        {
            { Direction.Left, Head.MoveLeft },
            { Direction.Right, Head.MoveRight},
            { Direction.Up, Head.MoveUp },
            { Direction.Down, Head.MoveDown }
        };
    }

    public void Move(Direction direction)
    {
        DirectionDictionary[direction]();

        if (!IsTailInRangeOfHead())
        {

        }
    }

    private bool AreValuesClose(int valueOne, int valueTwo)
    {
        int difference = valueTwo - valueOne;

        return difference >=
    }

    private bool IsTailInRangeOfHead()
    { 
        if (Head.Coord.X == Tail.Coord.X)
        {

        }
        else if (Head.Coord.Y == Tail.Coord.Y)
        {

        }
    }
}
