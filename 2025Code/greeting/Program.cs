using static System.Console;
using SplashKitSDK;

Greeting g = new Greeting("How are you");
g.Greet("Jon");

class Greeting
{
    private string _message;

    public Greeting(string message)
    {
        _message = message;
    }

    public void Print()
    {
        WriteLine(_message);
    }

        public void Greet(string name)
    {
        WriteLine($"Hello {name}! {_message}");
    }

    public string Message
    {
        get
        {
            return _message;
        }
        set
        {
            _message = value;
        }
    }

}

