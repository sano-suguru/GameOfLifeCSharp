using ApplicationCore;
using Xunit;

namespace UnitTests;

public class CellTests
{
    [Fact(DisplayName = "コンストラクタに正しい引数が与えられた場合、プロパティが設定される")]
    public void Constructor_WithValidParameters_SetsProperties()
    {
        // Arrange
        int x = 1;
        int y = 2;
        var isAlive = true;

        // Act
        Cell cell = new(x, y, isAlive);

        // Assert
        Assert.Equal(x, cell.X);
        Assert.Equal(y, cell.Y);
        Assert.Equal(isAlive, cell.IsAlive);
    }
}
