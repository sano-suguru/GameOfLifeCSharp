using ApplicationCore;

namespace ConsoleGameOfLifeApp;

public class ConsoleRenderer : RendererBase
{
    public override void Render(Cell[,] cells)
    {
        Console.Clear();

        for (int y = 0; y < cells.GetLength(1); y++)
        {
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                if (cells[x, y].IsAlive)
                {
                    Console.Write("■ ");
                }
                else
                {
                    Console.Write("□ ");
                }
            }
            Console.WriteLine();
        }
    }
}
