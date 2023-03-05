using ApplicationCore;
using ConsoleGameOfLifeApp;

World world = new(width: 30, height: 30, new ConsoleRenderer());

while (true)
{
    world.Render();
    world.NextGeneration();
    await Task.Delay(1000);
}
