using Job_Tracker_Api.Model.Entities;

namespace Job_Tracker_Api.Model.DTOs
{
    public class ApplicationReturnDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company_Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string Details { get; set; }

        public void ApplicationToDTO(Application app)
        {
            this.Id = app.Id;
            this.Title = app.Title;
            this.Company_Name = app.Company_Name;
            this.Location = app.Location;
            this.Date = app.Date;
            this.Status = app.Status;
            this.Details = app.Details;
        }
    }
}