namespace VendingMachine.Tests;

public class CoinTests
{
    [Fact]
    public void Parse_ValidCoins_ReturnsCorrectValue()
    {
        // Arrange
        var coin = new Coin();

        // Act And Assert
        Assert.Equal(100, coin.Parse("1E"));
        Assert.Equal(200, coin.Parse("2E"));
        Assert.Equal(50, coin.Parse("50C"));
        Assert.Equal(20, coin.Parse("20C"));
        Assert.Equal(10, coin.Parse("10C"));
    }

    [Fact]
    public void Parse_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        var coin = new Coin();

        // Act and Assert
        Assert.Throws<FormatException>(() => coin.Parse("3E"));
        Assert.Throws<FormatException>(() => coin.Parse("1D"));
        Assert.Throws<FormatException>(() => coin.Parse("50"));
        Assert.Throws<FormatException>(() => coin.Parse("20Cents"));
    }
}
