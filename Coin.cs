namespace VendingMachine;

public class Coin()
{
    public double Parse(string input)
    {
        var result = 0d;

        if (input.Length == 4 && input[1] == '.' && input[3] == 'E')
        {
            if (input[0] == '1' || input[0] == '2')
            {
                switch (input[0])
                {
                    case '1':
                        result += 100;
                        break;
                    case '2':
                        result += 200;
                        break;
                    default:
                        throw new FormatException();
                }
            }
            if (input[2] == '1' || input[2] == '2' || input[2] == '5')
            {
                switch (input[2])
                {
                    case '1':
                        result += 10;
                        break;
                    case '2':
                        result += 20;
                        break;
                    case '5':
                        result += 50;
                        break;
                    default:
                        throw new FormatException();
                }
            }
        }
        else
        {
            switch (input)
            {
                case "1E":
                    result += 100;
                    break;
                case "2E":
                    result += 200;
                    break;
                case "50C":
                    result += 50;
                    break;
                case "20C":
                    result += 20;
                    break;
                case "10C":
                    result += 10;
                    break;
                default:
                    throw new FormatException();
            }
        }

        return result;
        // if (input.Length == 3 && input[2] == 'C' && Char.IsDigit(input[0]) && Char.IsDigit(input[1]) && (int.Parse(input[0].ToString()) == 1 || int.Parse(input[0].ToString()) == 2 || int.Parse(input[0].ToString()) == 5) && int.Parse(input[1].ToString()) == 0)
        // {
        //     return int.Parse(input.Trim('C'));
        // }
        // else if (input.Length == 2 && input[1] == 'E' && Char.IsDigit(input[0]) && int.Parse(input[0].ToString()) <= 2 && int.Parse(input[0].ToString()) > 0)
        // {
        //     return int.Parse(input.Trim('E')) * 100;
        // }
    }
}