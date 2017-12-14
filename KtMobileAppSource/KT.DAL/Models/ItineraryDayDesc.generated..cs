using SQLite;

namespace KT.DAL.Models
{
    public class ItineraryDayDesc
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ItineraryDayId { get; set; }
        public int ItineraryId { get; set; }
        public int TimeOfDayId { get; set; }
        public string CustomDisplayName { get; set; }
        public string ActivityTypeDisplayName { get; set; }
        public int? DisplayOrder { get; set; }
        public string Description { get; set; }
        public string Alerts { get; set; }
        public string TermsAndConditions { get; set; }
        public string SourceName { get; set; }
        public string DestName { get; set; }
    }
}
