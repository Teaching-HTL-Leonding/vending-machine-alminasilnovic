namespace VendingMachine.Tests;

public class ChangeCalculatorTests
{
    [Fact]
    public void TotalAmount_InitiallyZero()
    {
        // Arrange
        var calc = new ChangeCalculator(100, 0);

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => calc.GetChange());
    }

    [Fact]
    public void TotalAmount_CorrectlyUpdatedWhenAddingCoins()
    {
        // Arrange
        var calc = new ChangeCalculator(100, 0);

        // Act
        calc.AddCoin(100);

        // Assert
        Assert.Equal(100, calc.TotalAmount);
    }

    [Fact]
    public void AddCoin_ThrowsOverflowException_IfTotalAmountExceedsMaxValue()
    {
        // Arrange
        var calc = new ChangeCalculator(100, double.MaxValue);

        // Act and Assert
        Assert.Throws<OverflowException> (() => calc.AddCoin(10000000));
    }

    [Fact]
    public void IsEnoughMoney_ReturnsTrue_IfTotalAmountIsEqualToOrGreaterThanProductPrice()
    {
        // Arrange
        var calc1 = new ChangeCalculator(100, 200); 
        // Act and Assert
        Assert.True(calc1.IsEnoughMoney);

        // Arrange
        var calc2 = new ChangeCalculator(100, 50); 
        // Act and Assert
        Assert.False(calc2.IsEnoughMoney);
    }

    [Fact]
    public void GetChange_ReturnsCorrectChange()
    {
        // Arrange
        var calc = new ChangeCalculator(100, 250);

        // Act and Assert
        Assert.Equal(150, calc.GetChange()); 
    }

    [Fact]
    public void GetChange_ThrowsInvalidOperationException_IfTotalAmountIsLessThanProductPrice()
    {
        // Arrange
        var calc = new ChangeCalculator(100, 50);

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => calc.GetChange());
    }

}
