namespace ApplicationCore;

public record Cell(int X, int Y, bool IsAlive)
{
    public Cell(int x, int y) : this(x, y, false) { }

    public Cell SetAlive() => this with { IsAlive = true };
    public Cell SetDead() => this with { IsAlive = false };
}
