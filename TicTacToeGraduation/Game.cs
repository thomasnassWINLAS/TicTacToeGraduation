﻿namespace TicTacToeGraduation;

public class Game
{
    private readonly IConsole _console;
    private readonly IRandom _random;
    public char[,] Board { get; } = new char[3, 3];
    private static Player _playerx = new Player("Player X", 'X');
    private static Player _playero = new Player("Player O", 'O');
    public Player CurrentPlayer = _playerx;

    public Game(IConsole console, IRandom random)
    {
        _console = console;
        _random = random;

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
    
    public void RunGame()
    {
        PrintBoard();
        _console.WriteLine("Board Created");
        _console.WriteLine($"{CurrentPlayer.Name} starts");
        int round = 0;
        while (!CheckWin() && round<=9)
        {
            var row= _random.Next(0, 3);
            var column = _random.Next(0, 3);
            MakeMove(row, column);
            round++;
            PrintBoard();
        }
        
    }

    public bool MakeMove(int row, int column)
    {
        if (Board[row, column] != ' ')
        {
            return false;
        }
        Board[row, column] = CurrentPlayer.Symbol;
        CurrentPlayer = CurrentPlayer == _playerx ? _playero : _playerx;
        return true;
    }

    public bool CheckWin()
    {
        for (int col = 0; col < 3; col++)
        {
            if (Board[0, col] == Board[1, col] && Board[1, col] == Board[2, col] && Board[0, col] != ' ')
            {
                CurrentPlayer = CurrentPlayer == _playerx ? _playero : _playerx;
                _console.WriteLine($"{CurrentPlayer.Name} wins!");
                return true;
            }
        }
        return false;
    }
}