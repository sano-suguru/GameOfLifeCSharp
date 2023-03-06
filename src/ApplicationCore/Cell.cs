namespace ApplicationCore;

public struct Cell
{
    public int X { get; }
    public int Y { get; }
    public bool IsAlive { get; private set; }

    public Cell((int x, int y) point, bool isAlive)
    {
        (X, Y) = point;
        IsAlive = isAlive;
    }
}