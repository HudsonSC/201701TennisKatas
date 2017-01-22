using System;

namespace TennisScoring
{
    public class TennisGame
    {
        public TennisGame(string player1, string player2)
        {
            Player1 = new PlayerStats(player1);
            Player2 = new PlayerStats(player2);
        }
        public PlayerStats Player1 { get; }
        public PlayerStats Player2 { get; }
        public string Winner { get; private set; }

        public string Advantage { get; set; }

        public void RecordPoint(PlayerStats player)
        {
            switch (player.Score)
            {
                case 0:
                    player.Score = 15;
                    break;
                case 15:
                    player.Score = 30;
                    break;
                case 30:
                    player.Score = 40;
                    if (Player1.Score == Player2.Score)
                    {
                        Winner = "deuce";
                    }
                    break;
                case 40:
                    if (Winner == "deuce")
                    {
                        if (Advantage == player.Name)
                        {
                            Winner = player.Name;
                            break;
                        }
                        Advantage = Advantage == string.Empty ? player.Name : string.Empty; 
                    }
                    else
                    {
                        Winner = player.Name;
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    public class PlayerStats
    {
        public PlayerStats(string playerName)
        {
            if (String.IsNullOrEmpty(playerName))
            {
                throw new ArgumentNullException(nameof(playerName));
            }
            Name = playerName;
        }
        public string Name { get; }
        public int Score { get; set; }
    }
}
