using SQLite;

namespace KT.DAL.Models
{
    public class ItineraryDays
    {
        [PrimaryKey]
        public int ItineraryDayId { get; set; }
        public string Day { get; set; }
        public int ItineraryId { get; set; }
        public string Notes { get; set; }
        public string Deleted { get; set; }
        public string ItineraryDayDate { get; set; }
        public string IsCustomDescription { get; set; }
        public string PictureId { get; set; }
        public string Summary { get; set; } // source|destination combination  
    }
}
