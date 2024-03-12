namespace VendingMachine;


public class ChangeCalculator(double price, double totalAmount)
{
    public double Price { get; set; } = price;

    public double TotalAmount { get; private set; } = totalAmount;

    public bool IsEnoughMoney => TotalAmount >= Price;

    public double AddCoin(double value)
    {
        return checked(TotalAmount += value);
    }

    public double GetChange()
    {
        if (!IsEnoughMoney)
        {
            throw new InvalidOperationException();
        }

        return TotalAmount - Price;
    }
}