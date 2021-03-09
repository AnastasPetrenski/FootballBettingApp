namespace P03_FootballBetting.Web.ViewModels.Towns
{
    public class CreateTownInputModel
    {
        //label name in Create.cshtml must be the same
        public string TownName { get; set; }

        public int CountryId { get; set; }
    }
}
