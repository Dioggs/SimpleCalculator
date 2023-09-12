using System.Text;

namespace calc;

class Tokenizer
{
    public string operation;
    public Tokenizer(string _operation)
    {
        operation = _operation;
    }

    public List<string> Tokenize()
    {
        StringBuilder sb = new();
        List<string> tokens = new();

        for (int i = 0; i < operation.Length; i++)
        {
            if (Char.IsDigit(operation[i]))
            {
                sb.Append(operation[i]);
                while (ValidateNextNumberChar(i))
                {
                    sb.Append(operation[i + 1]);
                    i++;
                }
                tokens.Add(sb.ToString());
                sb.Clear();
            }

            if(Char.IsSymbol(operation[i]) || Char.IsPunctuation(operation[i]))
            {
                sb.Append(operation[i]);
                while(ValidateNextOperatorChar(i))
                {
                    sb.Append(operation[i + 1]);
                    i++;
                }
                tokens.Add(sb.ToString());
                sb.Clear();
            }
        }
        return tokens;
    }

    // private bool Peek(int i)
    // {
    //     return i + 1 < operation.Length;
    // }

    private bool ValidateNextOperatorChar(int i)
    {
        return i + 1 < operation.Length && Char.IsSymbol(operation[i + 1]) || Char.IsPunctuation(operation[i + 1]);
    }

    private bool ValidateNextNumberChar(int i)
    {
        return i + 1 < operation.Length && Char.IsDigit(operation[i + 1]);
    }

}