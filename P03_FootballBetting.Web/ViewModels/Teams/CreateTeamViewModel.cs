using System.Collections.Generic;

namespace P03_FootballBetting.Web.ViewModels.Teams
{
    public class CreateTeamViewModel
    {
        public List<CreateColorsViewModel> Colors { get; set; }

        public List<CreateTownsViewModel> Towns { get; set; }
    }
}
