using P03_FootballBetting.Data.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P03_FootballBetting.Web.ViewModels.Games
{
    public class CreateGameInputModel
    {
        [Required]
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }
        
        [DataType(DataType.Date)]
        public string DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawBetRate { get; set; }

        public Prediction Result { get; set; }
    }
}
