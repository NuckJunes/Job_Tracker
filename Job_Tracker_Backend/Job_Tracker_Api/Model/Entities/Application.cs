
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
    }
}