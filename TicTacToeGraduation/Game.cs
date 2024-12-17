﻿namespace TicTacToeGraduation;

public class Game
{
    private readonly IConsole _console;
    public char[,] Board { get; } = new char[3, 3];
    
    public Game(IConsole console)
    {
        _console = console;

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
        _console.Write($"{Board[0, 0]}|{Board[0, 1]}|{Board[0, 2]}\n" +
                       $"-+-+-\n" +
                       $"{Board[1, 0]}|{Board[1, 1]}|{Board[1, 2]}\n" +
                       $"-+-+-\n" +
                       $"{Board[2, 0]}|{Board[2, 1]}|{Board[2, 2]}\n");
    }
    
    public static void Main(string[] args)
    {
        
    }

}
