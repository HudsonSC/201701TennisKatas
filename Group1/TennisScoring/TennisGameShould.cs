using Xunit;

namespace TennisScoring
{
    public class TennisGameShould
    {
        public string testPlayer1 = "one";
        public string testPlayer2 = "two";

        [Fact]
        public void HaveTwoPlayers()
        {
            var game = new TennisGame(testPlayer1, testPlayer2);

            Assert.Equal(testPlayer1, game.Player1.Name);
            Assert.Equal(testPlayer2, game.Player2.Name);
        }
        [Fact]
        public void HaveStartingScoreOfZero()
        {
            var game = new TennisGame(testPlayer1, testPlayer2);

            Assert.Equal(0, game.Player1.Score);
            Assert.Equal(0, game.Player2.Score);
        }
    }
}
