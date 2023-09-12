using calc;
using static System.Console;

class Program
{
    private static void Main()
    {
        BootCalculator();
    }
    

    private static void BootCalculator()
    {
        Calculator.PlayTitleScreen();
        User user = new("Diogo");
        string operation = user.GetUserInput();
        Tokenizer tokenizer = new(operation);
        List<string> tokens = tokenizer.Tokenize();
        Calculator.Calculate(tokens);
    }
} 