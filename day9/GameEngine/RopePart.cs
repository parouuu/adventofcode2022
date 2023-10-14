public class RopePart
{
    public Coord Coord { get; private set; }

    public RopePart()
    {
        Coord = new Coord();
    }

    public void MoveLeft() => Coord.MoveLeft();
    public void MoveRight() => Coord.MoveRight();
    public void MoveUp() => Coord.MoveUp();
    public void MoveDown() => Coord.MoveDown();

    private bool AreValuesClose(int valueOne, int valueTwo)
    {
        int difference = valueTwo - valueOne;
        return Math.Abs(difference) <= 1;
    }

    public bool IsInRangeOf(RopePart other) => AreValuesClose(this.Coord.X, other.Coord.X)
              && AreValuesClose(this.Coord.Y, other.Coord.Y);

    public void GetCloserTo(RopePart other)
    {
        int diffX = this.Coord.X - other.Coord.X;
        int diffY = this.Coord.Y - other.Coord.Y;

        int distX = Math.Abs(diffX);
        int distY = Math.Abs(diffY);

        if (diffX > 1 || (distY > 1 && diffX == 1))
        {
            this.Coord.MoveLeft();
        }
        else if (diffX < -1 || (distY > 1 && diffX == -1))
        {
            this.Coord.MoveRight();
        }

        if (diffY > 1 || (distX > 1 && diffY == 1))
        {
            this.Coord.MoveDown();
        }
        else if (diffY < -1 || (distX > 1 && diffY == -1))
        {
            this.Coord.MoveUp();
        }
    }
}
