using System;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Web.ViewModels.Games
{
    public class AllGamesViewModel
    {
        public int GameId { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawBetRate { get; set; }

        public string Result { get; set; }
    }
}
