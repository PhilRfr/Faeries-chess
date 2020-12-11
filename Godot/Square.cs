public class Square
{
    Piece piece;
    int side;

    public Square()
    {
        Piece = null;
        side = -1;
    }

    public int Side { get => side; set => side = value; }
    internal Piece Piece { get => piece; set => piece = value; }

    public bool CanTake(int side)
    {
        return this.piece == null || this.side != side;
    }

    public bool IsEmpty()
    {
        return piece == null;
    }
}