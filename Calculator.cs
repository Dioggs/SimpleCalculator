using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using static System.Console;
using static System.Convert;

namespace calc;

class Calculator
{
    const string logo = @"                                        
     ___ __ _| | ___ _   _| | __ _| |_ ___  _ __ 
    / __/ _` | |/ __| | | | |/ _` | __/ _ \| '__/ 
   | (_| (_| | | (__| |_| | | (_| | || (_) | |  
    \___\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|  " + "\n\n";

    const string resultLogo = @"┬─┐┌─┐┌─┐┬ ┬┬ ┌┬┐
├┬┘├┤ └─┐│ ││  │ 
┴└─└─┘└─┘└─┘┴─┘┴ ";

    private static readonly Dictionary<string, Func<int, int, int>> operations = new()
    {
        {"+", (int x, int y) => x + y},
        {"-", (int x, int y) => x - y},
        {"*", (int x, int y) => x * y},
        {"/", (int x, int y) => x / y}
    };

    public static void PlayTitleScreen()
    {
        WriteLine(logo);
    }

    public static void Calculate(List<string> tokens)
    {
        int result = 0;
        for(int i = 0; i < tokens.Count; i++)
        {
            Func<int, int, int>? op = GetValueOrDefault(i, tokens);
            if(op != null)
            {
                result = op(ToInt32(tokens[i - 1]), ToInt32(tokens[i + 1]));
                PrintResults(result);
            }
        }

    }

    private static Func<int, int, int>?  GetValueOrDefault(int i, List<string> tokens)
    {
        try 
        {
            return operations[tokens[i]];
        }
        catch(Exception)
        {
            return null;
        }
    }
    private static void PrintResults(int result)
    {
        Write(resultLogo);
        WriteLine($"----> {result}");
    }
}