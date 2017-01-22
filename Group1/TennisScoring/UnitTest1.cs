using Xunit;

namespace TennisScoring
{
    public class TennisGameRecordPointShould
    {
        public string testPlayer1 = "one";
        public string testPlayer2 = "two";


        [Theory]
        [InlineData(0, 15)]
        [InlineData(15, 30)]
        [InlineData(30, 40)]
        public void IncrementPlayerScoreCorrectly(int startScore, int newScore)
        {
            var game = new TennisGame(testPlayer1, testPlayer2);
            game.Player1.Score = startScore;

            game.RecordPoint(game.Player1);

            Assert.Equal(newScore, game.Player1.Score);
        }

        [Theory]
        [InlineData(0, "one")]
        [InlineData(15, "one")]
        [InlineData(30, "one")]
        public void SetWinnerWhenPlayer1ScoresWithCurrentScoreOf40(int otherPlayerScore,
            string winner)
        {
            var game = new TennisGame(testPlayer1, testPlayer2);
            game.Player1.Score = 40;
            game.Player2.Score = otherPlayerScore;

            game.RecordPoint(game.Player1);

            Assert.Equal(winner, game.Winner);
        }

        [Theory]
        [InlineData("one", "one", "one")]
        [InlineData("", "deuce", "one")]
        [InlineData("two", "deuce", "")]
        public void SetDeuceCorrectlyWhenPlayerOneScores(
            string startingAdvantage, string winner, string endingAdvantage)
        {
            var game = new TennisGame(testPlayer1, testPlayer2);
            game.Player1.Score = 30;
            game.Player2.Score = 40;
            game.Advantage = startingAdvantage;
            game.RecordPoint(game.Player1);
            game.RecordPoint(game.Player1);

            Assert.Equal(winner, game.Winner);
            Assert.Equal(endingAdvantage, game.Advantage);
        }
    }
}
