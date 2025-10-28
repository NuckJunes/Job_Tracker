using System.ComponentModel.DataAnnotations;
using Job_Tracker_Api.Model.DTOs;

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

        public void convertAccountDTOtoUser(AccountDTO accountDTO, string hashedPass)
        {
            this.Applications = new List<Application>();
            this.Username = accountDTO.Username;
            this.Password = hashedPass;
            this.IsDeleted = false;
            this.Email = accountDTO.Email;
        }
    }
}