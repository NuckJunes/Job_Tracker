using System.ComponentModel.DataAnnotations;

namespace Job_Tracker_Api.Model.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public List<Application> Applications { get; set; }
    }
}