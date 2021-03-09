using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models.Enumerations
{
    public enum Prediction
    {
        [Display(Name = "Win")]
        Win = 1,
        [Display(Name = "Lose")]
        Lose = 2,
        [Display(Name = "Draw")]
        Draw = 3
    }
}
    