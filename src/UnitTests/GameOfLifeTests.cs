using ApplicationCore;
using Xunit;

namespace UnitTests;

public class GameOfLifeTests
{
    [Fact(DisplayName = "死んでいるセルに隣接する生きたセルがちょうど3つあれば、次の世代が誕生すること")]
    public void Test_GameOfLife_Birth()
    {
        // Arrange
        Cell[,] initialState = new Cell[3, 3]
        {
            { new Cell((0,0), true), new Cell((1,0), true), new Cell((2,0), false) },
            { new Cell((0,1), true), new Cell((1,1), false), new Cell((2,1), false) },
            { new Cell((0,2), false), new Cell((1,2), false), new Cell((2,2), false) }
        };
        MockRenderer renderer = new MockRenderer(grid =>
        {
            Assert.True(grid[1, 1].IsAlive);
        });
        GameOfLife game = new GameOfLife(initialState, renderer);

        // Act
        game.AdvanceGeneration();

        // Assert
        game.Render();
    }

    [Fact(DisplayName = "生きているセルに隣接する生きたセルが2つか3つならば、次の世代でも生存すること")]
    public void Test_GameOfLife_Survival()
    {
        // Arrange
        Cell[,] initialState = new Cell[4, 4]
        {
            { new Cell((0,0), false), new Cell((1,0), false), new Cell((2,0), false), new Cell((3, 0), false) },
            { new Cell((0,1), false), new Cell((1,1), true), new Cell((2,1), true), new Cell((3, 0), false) },
            { new Cell((0,2), false), new Cell((1,2), true), new Cell((2,2), true), new Cell((3, 0), false) },
            { new Cell((0,2), false), new Cell((1,2), false), new Cell((2,2), false), new Cell((3, 0), false) },
        };
        MockRenderer renderer = new MockRenderer(grid =>
        {
            Assert.True(grid[1, 1].IsAlive);
        });
        GameOfLife game = new GameOfLife(initialState, renderer);

        // Act
        game.AdvanceGeneration();

        // Assert
        game.Render();
    }

    [Fact(DisplayName = "生きているセルに隣接する生きたセルが1つ以下ならば、過疎により死滅すること")]
    public void Test_GameOfLife_Underpopulation()
    {
        // Arrange
        Cell[,] initialState = new Cell[3, 3]
        {
            { new Cell((0,0), false), new Cell((1,0), false), new Cell((2,0), false) },
            { new Cell((0,1), false), new Cell((1,1), true), new Cell((2,1), true) },
            { new Cell((0,2), false), new Cell((1,2), false), new Cell((2,2), false) }
        };
        MockRenderer renderer = new MockRenderer(grid =>
        {
            Assert.False(grid[1, 1].IsAlive);
        });
        GameOfLife game = new GameOfLife(initialState, renderer);

        // Act
        game.AdvanceGeneration();

        // Assert
        game.Render();
    }

    [Fact(DisplayName = "生きているセルに隣接する生きたセルが4つ以上ならば、過密により死滅すること")]
    public void Test_GameOfLife_Overcrowding()
    {
        // Arrange
        var initialState = new Cell[,]
        {
            { new Cell((0, 0), true), new Cell((1, 0), true), new Cell((2, 0), true) },
            { new Cell((0, 1), true), new Cell((1, 1), true), new Cell((2, 1), false) },
            { new Cell((0, 2), false), new Cell((1, 2), false), new Cell((2, 2), false) }
        };
        var renderer = new MockRenderer(grid =>
        {
            Assert.False(grid[1,1].IsAlive);
        });
        var game = new GameOfLife(initialState, renderer);

        // Act
        game.AdvanceGeneration();

        // Assert
        game.Render();
    }
}

public class MockRenderer : RendererBase
{
    private readonly Action<Cell[,]> _onRender;

    public MockRenderer(Action<Cell[,]> onRender)
    {
        _onRender = onRender;
    }

    public override void Render(Cell[,] grid)
    {
        _onRender(grid);
    }
}
