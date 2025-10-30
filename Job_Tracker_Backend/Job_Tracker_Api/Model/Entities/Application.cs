
using Job_Tracker_Api.Model.DTOs;

namespace Job_Tracker_Api.Model.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Company_Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public int Status { get; set; }
        //1 = Active, 2 = Interviewing, 3 = Offer, 4 = Rejected
        public bool IsDeleted { get; set; }

        public void convertApplicationDTOtoApplication(ApplicationDTO appDTO, User user)
        {
            this.Location = appDTO.Location;
            this.Status = appDTO.Status;
            this.Company_Name = appDTO.Company_Name;
            this.Date = appDTO.Date;
            this.Title = appDTO.Title;
            this.Details = appDTO.Details;
            this.IsDeleted = false;
            this.User = user;
        }

        public void updateApplication(ApplicationDTO appDTO)
        {
            this.Location = appDTO.Location;
            this.Status = appDTO.Status;
            this.Company_Name = appDTO.Company_Name;
            this.Title = appDTO.Title;
            this.Details = appDTO.Details;
        }
    }
}