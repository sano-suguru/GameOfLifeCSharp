using ApplicationCore;
using ConsoleGameOfLifeApp;

GameOfLife game = new(width: 30, height: 30, new ConsoleRenderer());

while (true)
{
    game.Render();
    game.AdvanceGeneration();
    await Task.Delay(1000);
}
