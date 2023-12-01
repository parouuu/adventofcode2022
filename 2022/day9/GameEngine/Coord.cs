public class Coord
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Coord()
    {
        X = 0;
        Y = 0;
    }

    public Coord(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void MoveLeft() => X--;
    public void MoveRight() => X++;
    public void MoveUp() => Y++;
    public void MoveDown() => Y--;

    public override bool Equals(object obj)
    {
        return obj is Coord coord &&
               X == coord.X &&
               Y == coord.Y;
    }
}
