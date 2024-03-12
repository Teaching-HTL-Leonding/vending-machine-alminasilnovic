namespace VendingMachine.Tests;

public class CoinHandlingConsoleMock(string[] inputs) : CoinHandlingConsole
{
    private int inputIndex = 0;
    public List<string> Outputs { get; } = [];

    private int NumberOfReadLineCommands { get; set; }

    public override string ReadLine()
    {
        Assert.True(NumberOfReadLineCommands < inputs.Length, "ReadLine called too many times");
        string input = inputs[inputIndex];
        inputIndex++;
        return input;
    }

    public override void WriteLine(string value) => Outputs.Add(value);
}