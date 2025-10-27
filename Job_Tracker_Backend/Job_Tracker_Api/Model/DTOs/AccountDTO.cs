using System.ComponentModel.DataAnnotations;

namespace Job_Tracker_Api.Model.DTOs
{
    public class AccountDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}