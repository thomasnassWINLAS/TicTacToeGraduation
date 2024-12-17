namespace TicTacToeGraduation;

public class Game
{
    public char[,] Board { get; } = new char[3, 3];
    
    public Game()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Board[i, j] = ' ';
            }
        }
    }
    public static void Main(string[] args)
    {
        
    }
}
