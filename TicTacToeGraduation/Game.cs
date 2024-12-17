namespace TicTacToeGraduation;

public class Game
{
    public char[,] Board { get; } = new char[3, 3];
    
    public Game(IConsole console)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Board[i, j] = ' ';
            }
        }
    }
    public void PrintBoard()
    {
        throw new NotImplementedException();
    }
    
    public static void Main(string[] args)
    {
        
    }

}
