using P03_FootballBetting.Data.Models.Enumerations;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Web.ViewModels.Games
{
    public class CreateGameViewModel
    {
        public List<CreateAwayTeamViewModel> AwayTeams { get; set; }

        public List<CreateHomeTeamViewModel> HomeTeams { get; set; }

        public List<Prediction> Predict { get; set; }

        [DataType(DataType.Date)]
        public string DateTime { get; set; }
    }
}
