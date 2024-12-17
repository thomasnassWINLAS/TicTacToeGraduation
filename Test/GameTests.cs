using NSubstitute;
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
    
    [Fact(DisplayName = "RunGame should say 'Board Created'")]
    public void RunGame_ShouldSay_BoardCreated()
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);

        // Act
        game.RunGame();
        // Assert
        console.Received().WriteLine("Board Created");
    }
    
    [Fact(DisplayName = "RunGame should print empty board")]
    public void RunGame_ShouldPrintEmptyBoard()
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);
        
        // Act
        game.RunGame();
        
        // Assert
        console.Received().Write(" | | \n-+-+-\n | | \n-+-+-\n | | \n");
    }
    
    [Fact(DisplayName = "RunGame should print that Player X starts")]
    public void RunGame_ShouldPrintPlayerXStarts()
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);
        
        // Act
        game.RunGame();
        
        // Assert
        console.Received().WriteLine("Player X starts");
    }
    
    [Fact(DisplayName = "Player X can make a move")]
    public void PlayerX_CanMakeMove()
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);
        
        // Act
        game.MakeMove(0, 0);
        
        // Assert
        Assert.Equal('X', game.Board[0, 0]);
    }
    
    [Fact(DisplayName = "Players take turns")]
    public void Players_TakeTurns()
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);
        
        // Act
        game.MakeMove(0, 0);
        game.MakeMove(0, 1);
        
        // Assert
        Assert.Equal('O', game.Board[0, 1]);
    }
    
    [Fact(DisplayName = "Players can't make a move on a taken cell")]
    public void Players_CantMakeMoveOnTakenCell()
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);
        
        // Act
        game.MakeMove(0, 0);
        var result = game.MakeMove(0, 0);
        
        // Assert
        Assert.False(result);
    }
    
    [Theory(DisplayName = "Players X wins on the vertical")]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(2, 0)]
    public void PlayerX_WinsVertically(int colX,int colO)
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);
        
        // Act
        game.MakeMove(0, colX);
        game.MakeMove(0, colO);
        game.MakeMove(1, colX);
        game.MakeMove(1, colO);
        game.MakeMove(2, colX);
        
        // Assert
        Assert.True(game.CheckWin());
    }
    [Fact(DisplayName = "Players O wins on the vertical is printed")]
    public void PlayerO_WinsVertically()
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);
        
        // Act
        game.MakeMove(0, 2);
        game.MakeMove(0, 0);
        game.MakeMove(1, 2);
        game.MakeMove(1, 0);
        game.MakeMove(2, 1);
        game.MakeMove(2, 0);
        game.CheckWin();
        
        // Assert
        console.Received().WriteLine("Player O wins!");
    }
    
    [Fact(DisplayName = "RunGame player X wins horizontally is printed")]
    public void RunGame_PlayerXWinsHorizontally()
    {
        // Arrange
        var console = Substitute.For<IConsole>();
        var game = new Game(console);
        
        // Act
        game.RunGame();
        
        // Assert
        console.Received().WriteLine("Player X wins!");
    }
    
}