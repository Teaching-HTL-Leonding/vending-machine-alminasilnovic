namespace VendingMachine.Tests;

public class CoinHandlingConsoleTests
{
    [Fact]
    public void TestExactProductPriceNoChange()
    {
        // Arrange
        var chc = new CoinHandlingConsoleMock(["1.5E", "1E", "50C"]);

        // Act
        chc.HandleCoins();

        // Assert
        Assert.Equal(["Change: 0E"], chc.Outputs);
    }

    [Fact]
    public void TestExceedingProductPriceWithChange()
    {
        // Arrange
        var chc = new CoinHandlingConsoleMock(["1.5E", "1E", "2E"]);

        // Act
        chc.HandleCoins();

        // Assert
        Assert.Equal(["Change: 1,5E"], chc.Outputs);
    }

    [Fact]
    public void TestInvalidCoin()
    {
        // Arrange
        var chc = new CoinHandlingConsoleMock(["1.5E", "3E", "1E", "50C"]);

        // Act
        chc.HandleCoins();

        // Assert
        Assert.Equal(["Invalid coin", "Change: 0E"], chc.Outputs);
    }
}
