namespace TicTacToeGraduation;

public class Program
{
    public static void Main(string[] args)
    {
        var console = new ConsoleWrapper();
        var random = new RandomWrapper();
        var game = new Game(console, random);
        game.RunGame();
    }
}

public class RandomWrapper : IRandom
{
    private readonly Random _random = new();
    public int Next(int minValue, int maxValue) => _random.Next(minValue, maxValue);
}

public class ConsoleWrapper : IConsole
{
    public void Write(string message)
    {
        Console.Write(message);
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}