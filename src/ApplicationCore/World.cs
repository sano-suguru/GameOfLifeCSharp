namespace ApplicationCore;

public class World
{
    private readonly int width;
    private readonly int height;
    private readonly RendererBase renderer;
    private Cell[,] cells;

    public World(int width, int height, RendererBase renderer)
    {
        this.width = width;
        this.height = height;
        this.renderer = renderer;
        cells = new Cell[width, height];

        Random random = new();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (random.Next(0, 2) == 1)
                {
                    cells[x, y] = new Cell(x, y);
                    cells[x, y] = cells[x, y].SetAlive();
                }
                else
                {
                    cells[x, y] = new Cell(x, y);
                }
            }
        }
    }

    public void NextGeneration()
    {
        Cell[,] newCells = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int numAliveNeighbors = CountAliveNeighbors(x, y);

                if (cells[x, y].IsAlive)
                {
                    if (numAliveNeighbors < 2 || numAliveNeighbors > 3)
                    {
                        newCells[x, y] = cells[x, y].SetDead();
                    }
                    else
                    {
                        newCells[x, y] = cells[x, y];
                    }
                }
                else
                {
                    if (numAliveNeighbors == 3)
                    {
                        newCells[x, y] = new Cell(x, y);
                        newCells[x, y] = newCells[x, y].SetAlive();
                    }
                    else
                    {
                        newCells[x, y] = cells[x, y];
                    }
                }
            }
        }

        this.cells = newCells;
    }

    public void Render()
    {
        renderer.Render(cells);
    }

    private int CountAliveNeighbors(int x, int y)
    {
        int count = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;

                int neighborX = x + i;
                int neighborY = y + j;

                if (neighborX < 0)
                {
                    neighborX = width - 1;
                }
                else if (neighborX >= width)
                {
                    neighborX = 0;
                }

                if (neighborY < 0)
                {
                    neighborY = height - 1;
                }
                else if (neighborY >= height)
                {
                    neighborY = 0;
                }

                if (cells[neighborX, neighborY].IsAlive)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
