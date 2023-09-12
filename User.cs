using static System.Console;

namespace calc;

class User 
{
    string _userName;

    public User(string userName)
    {
        _userName = userName;
    }

    public string GetUserInput()
    {
        Write("Operation: ");
        string operation = ReadLine()!;
        return operation;
    }
}