using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P03_FootballBetting.Web.ViewModels.Players
{
    public class AllPlayersViewModel
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public string Team { get; set; }

        public string Position { get; set; }

        public bool IsInjured { get; set; }
    }
}
