namespace ApplicationCore;

public class NeighborCounter
{
    private readonly Cell[,] _grid;
    private readonly int _width;
    private readonly int _height;

    public NeighborCounter(Cell[,] grid)
    {
        _grid = grid;
        _width = _grid.GetLength(0);
        _height = _grid.GetLength(1);
    }

    public int CountLiveNeighbors(int x, int y)
    {
        int count = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                // 自分自身との比較は不要
                if (i == 0 && j == 0)
                {
                    continue;
                }

                int neighborX = x + i;
                int neighborY = y + j;

                // グリッドの範囲外の場合はスキップする
                if (neighborX < 0 || neighborX >= _width || neighborY < 0 || neighborY >= _height)
                {
                    continue;
                }

                if (_grid[neighborX, neighborY].IsAlive)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
