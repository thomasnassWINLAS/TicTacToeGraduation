using TicTacToeGraduation;

namespace Test;

public class GameTests
{
    [Fact(DisplayName = "Game board is 3 by 3")]
    public void Game_Board_ShouldBe3x3()
    {
        // Arrange
        var game = new Game();
        
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
        var game = new Game();
        
        // Act
        var board = game.Board;
        
        // Assert
        foreach (var cell in board)
        {
            Assert.Equal(' ', cell);
        }
    }
}
