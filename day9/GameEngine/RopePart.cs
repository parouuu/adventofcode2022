public class RopePart
{
    public RopePartType Type { get; private set; }
    public Coord Coord { get; private set; }

    public RopePart(RopePartType type)
    {
        Type = type;
        Coord = new Coord();
    }

    public void MoveLeft() => Coord.MoveLeft();
    public void MoveRight() => Coord.MoveRight();
    public void MoveUp() => Coord.MoveUp();
    public void MoveDown() => Coord.MoveDown();
}
