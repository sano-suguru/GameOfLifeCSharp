using ApplicationCore;
using Xunit;

namespace UnitTests;

public class CellTests
{
    [Fact(DisplayName = "コンストラクタに正しい引数が与えられた場合、プロパティが設定される")]
    public void Constructor_WithValidParameters_SetsProperties()
    {
        // Arrange
        var point = (2, 3);
        var isAlive = true;

        // Act
        var cell = new Cell(point, isAlive);

        // Assert
        Assert.Equal(point.Item1, cell.X);
        Assert.Equal(point.Item2, cell.Y);
        Assert.Equal(isAlive, cell.IsAlive);
    }
}
