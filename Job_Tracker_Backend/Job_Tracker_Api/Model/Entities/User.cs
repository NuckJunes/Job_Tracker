using System.ComponentModel.DataAnnotations;
using Job_Tracker_Api.Model.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Job_Tracker_Api.Model.Entities
{
    public class User : IdentityUser
    {
        
        public List<Application> Applications { get; set; }
        public bool IsDeleted { get; set; }

        public void convertAccountDTOtoUser(AccountDTO accountDTO, string hashedPass)
        {
            this.Applications = new List<Application>();
            this.UserName = accountDTO.Username;
            this.PasswordHash = hashedPass;
            this.IsDeleted = false;
            this.Email = accountDTO.Email;
        }
    }
}