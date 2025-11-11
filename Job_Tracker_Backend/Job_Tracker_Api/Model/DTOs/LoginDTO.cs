using System.ComponentModel.DataAnnotations;

namespace Job_Tracker_Api.Model.DTOs
{
    public class LoginDTO
    {
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}