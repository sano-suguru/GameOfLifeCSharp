namespace ApplicationCore;

public readonly struct Cell
{
    public int X { get; }
    public int Y { get; }
    public bool IsAlive { get; }

    public Cell(int x, int y, bool isAlive)
    {
        (X, Y) = (x, y);
        IsAlive = isAlive;
    }
}