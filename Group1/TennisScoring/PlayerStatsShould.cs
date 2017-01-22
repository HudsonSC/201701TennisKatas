using System;
using Xunit;

namespace TennisScoring
{
    public class PlayerStatsShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RequireName(string playerName)
        {
            Assert.Throws<ArgumentNullException>(() => new PlayerStats(playerName));
        }
    }
}
