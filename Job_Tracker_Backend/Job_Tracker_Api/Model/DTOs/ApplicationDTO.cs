namespace Job_Tracker_Api.Model.DTOs
{
    public class ApplicationDTO
    {
        public string Title { get; set; }
        public string Company_Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string Details { get; set; }
    }
}