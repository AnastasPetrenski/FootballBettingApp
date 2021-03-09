using P03_FootballBetting.Data.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P03_FootballBetting.Web.ViewModels.Players
{
    public class CreatePlayerViewModel
    {
        public List<CreatePositionsViewModel> Positions { get; set; }

        public List<CreateTeamsViewModel> Teams { get; set; }

    }
}
