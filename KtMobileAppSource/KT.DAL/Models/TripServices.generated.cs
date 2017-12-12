using SQLite;

namespace KT.DAL.Models
{
    public class TripServices
    {       
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItineraryId { get; set; }
        public string RefNum { get; set; }
        public string StartDate { get; set; }
        public int NoOfDays { get; set; }
        public int NoOfPeople { get; set; }
        public string GroupName { get; set; }
        public string ImageSrc { get; set; }
        public int IsArchived { get; set; }
    }
}
