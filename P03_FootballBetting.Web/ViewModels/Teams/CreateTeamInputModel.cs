using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P03_FootballBetting.Web.ViewModels.Teams
{
    public class CreateTeamInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        [Required]
        [StringLength(3)]
        public string Initials { get; set; }

        [Required]
        public decimal Budget { get; set; }

        [Required]
        public int PrimaryKitColorId { get; set; }

        [Required]
        public int SecondaryKitColorId { get; set; }

        [Required]
        public int TownId { get; set; }
    }
}
