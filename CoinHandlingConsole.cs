using System.Linq.Expressions;

namespace VendingMachine;


public class CoinHandlingConsole()
{
    public virtual void Write(string s) => Console.Write(s);

    public virtual void WriteLine(string s) => Console.WriteLine(s);

    public virtual string ReadLine() => Console.ReadLine()!;

    public void HandleCoins()
    {

        var coin = new Coin();
        var calc = new ChangeCalculator(0d, 0d);

        Write("Price: ");
        try
        {
            calc.Price = coin.Parse(ReadLine());
        }
        catch (FormatException)
        {
            WriteLine("Invalid coin");
        }



        while (calc.TotalAmount < calc.Price)
        {
            Write("Coin: ");
            var userCoin = ReadLine();

            try
            {
                calc.AddCoin(coin.Parse(userCoin));

                Write($"Total: {calc.TotalAmount / 100}E\n");
            }
            catch (FormatException)
            {
                WriteLine("Invalid coin");
            }
        }

        calc = new ChangeCalculator(calc.Price, calc.TotalAmount);

        try
        {
            WriteLine($"Change: {calc.GetChange() / 100}E");
        }
        catch (InvalidOperationException)
        {
            WriteLine("The operation used is invalid");
        }
    }
}