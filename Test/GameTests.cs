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
}
