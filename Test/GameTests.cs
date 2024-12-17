﻿using NSubstitute;
using TicTacToeGraduation;

namespace Test;

public class GameTests
{
    [Fact(DisplayName = "Game board is 3 by 3")]
    public void Game_Board_ShouldBe3x3()
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);
        
        // Act
        var board = game.Board;
        
        // Assert
        Assert.Equal(3, board.GetLength(0));
        Assert.Equal(3, board.GetLength(1));
    }
    
    [Fact(DisplayName = "Check that board empty")]
    public void Check_BoardIsEmpty()
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);
        
        // Act
        var board = game.Board;
        
        // Assert
        foreach (var cell in board)
        {
            Assert.Equal(' ', cell);
        }
    }
    
    [Fact(DisplayName = "Print empty board prints empty board")]
    public void PrintEmptyBoard_PrintsEmptyBoard()
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);
        
        // Act
        game.PrintBoard();
        
        // Assert
        console.Received().Write(" | | \n-+-+-\n | | \n-+-+-\n | | \n");
    }
}