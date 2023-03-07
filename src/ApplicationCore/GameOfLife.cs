namespace ApplicationCore;

public class GameOfLife
{
    private Cell[,] _grid;
    private readonly RendererBase _renderer;
    private NeighborCounter _neighborCounter;
    private readonly int _width;
    private readonly int _height;

    public GameOfLife(Cell[,] initialState, RendererBase renderer)
    {
        _width = initialState.GetLength(dimension: 0);
        _height = initialState.GetLength(dimension: 1);
        _grid = initialState;
        _renderer = renderer;
        _neighborCounter = new NeighborCounter(_grid);
    }

    public GameOfLife(int width, int height, RendererBase renderer)
    {
        _width = width;
        _height = height;
        _grid = new Cell[width, height];
        _renderer = renderer;

        Random random = new();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                bool isAlive = random.Next(0, 2) == 1;

                _grid[x, y] = new Cell(x, y, isAlive);
            }
        }

        _neighborCounter = new NeighborCounter(_grid);
    }

    public void AdvanceGeneration()
    {
        Cell[,] nextGeneration = new Cell[_width, _height];

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                int liveNeighbors = _neighborCounter.CountLiveNeighbors(i, j);

                bool nextCellState = _grid[i, j].IsAlive;

                if (_grid[i, j].IsAlive)
                {
                    if (liveNeighbors < 2 || liveNeighbors > 3)
                    {
                        nextCellState = false;
                    }
                }
                else
                {
                    if (liveNeighbors == 3)
                    {
                        nextCellState = true;
                    }
                }

                nextGeneration[i, j] = new Cell(x: i, y: j, nextCellState);
            }
        }

        _grid = nextGeneration;
        _neighborCounter = new NeighborCounter(_grid);
    }

    public void Render()
    {
        _renderer.Render(_grid);
    }
}
