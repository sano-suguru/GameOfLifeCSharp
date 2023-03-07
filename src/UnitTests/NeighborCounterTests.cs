using ApplicationCore;
using Xunit;

namespace UnitTests;

public class NeighborCounterTests
{
    [Fact(DisplayName = "CountLiveNeighborsが、近隣に生きたセルがない場合、0を返すこと")]
    public void CountLiveNeighbors_ReturnsZero_WhenNoNeighborsAreAlive()
    {
        // Arrange
        var grid = new Cell[,]
        {
            { new Cell(x: 0, y: 0, isAlive: false), new Cell(x: 1, y: 0, isAlive: false), new Cell(x: 2, y: 0, isAlive: false) },
            { new Cell(x: 0, y: 1, isAlive: false), new Cell(x: 1, y: 1, isAlive: false), new Cell(x: 2, y: 1, isAlive: false) },
            { new Cell(x: 0, y: 2, isAlive: false), new Cell(x: 1, y: 2, isAlive: false), new Cell(x: 2, y: 2, isAlive: false) },
        };
        var counter = new NeighborCounter(grid);

        // Act
        var count = counter.CountLiveNeighbors(1, 1);

        // Assert
        Assert.Equal(0, count);
    }

    [Fact(DisplayName = "CountLiveNeighborsが、近隣にいくつかの生きたセルがある場合、正しい数を返すこと")]
    public void CountLiveNeighbors_ReturnsCorrectCount_WhenSomeNeighborsAreAlive()
    {
        // Arrange
        var grid = new Cell[,]
        {
            { new Cell(x: 0, y: 0, isAlive: true), new Cell(x: 1, y: 0, isAlive: false), new Cell(x: 2, y: 0, isAlive: false) },
            { new Cell(x: 0, y: 1, isAlive: false), new Cell(x: 1, y: 1, isAlive: true), new Cell(x: 2, y: 1, isAlive: true) },
            { new Cell(x: 0, y: 2, isAlive: false), new Cell(x: 1, y: 2, isAlive: false), new Cell(x: 2, y: 2, isAlive: false) },
        };
        var counter = new NeighborCounter(grid);

        // Act
        var count = counter.CountLiveNeighbors(1, 1);

        // Assert
        Assert.Equal(2, count);
    }

    [Fact(DisplayName = "CountLiveNeighborsが、グリッドの範囲外のセルを無視して、正しい数を返すこと")]
    public void CountLiveNeighbors_IgnoresCellsOutsideGrid()
    {
        // Arrange
        var grid = new Cell[,]
        {
            { new Cell(x: 0, y: 0, isAlive: true), new Cell(x: 1, y: 0, isAlive: false), new Cell(x: 2, y: 0, isAlive: false) },
            { new Cell(x: 0, y: 1, isAlive: false), new Cell(x: 1, y: 1, isAlive: true), new Cell(x: 2, y: 1, isAlive: false) },
            { new Cell(x: 0, y: 2, isAlive: false), new Cell(x: 1, y: 2, isAlive: false), new Cell(x: 2, y: 2, isAlive: false) },
        };
        var counter = new NeighborCounter(grid);

        // Act
        var count = counter.CountLiveNeighbors(0, 0);

        // Assert
        Assert.Equal(1, count);
    }
}
