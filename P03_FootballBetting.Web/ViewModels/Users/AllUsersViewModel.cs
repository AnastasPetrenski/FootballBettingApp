using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Web.ViewModels.Users
{
    public class AllUsersViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
