using System.ComponentModel.DataAnnotations;
using Job_Tracker_Api.Model.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Job_Tracker_Api.Model.Entities
{
    public class User : IdentityUser
    {
        
        public List<Application> Applications { get; set; }
        public bool IsDeleted { get; set; }

        public void convertAccountDTOtoUser(AccountDTO accountDTO)
        {
            this.Applications = new List<Application>();
            this.UserName = accountDTO.UserName;
            this.IsDeleted = false;
            this.Email = accountDTO.Email;
        }
    }
}